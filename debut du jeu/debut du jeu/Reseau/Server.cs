using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Templar
{
    class Server
    {
        IFormatter Serialiseur;
        gamemain Infos;
        int Type = 0;
        private int port;
        TcpClient Client;
        TcpListener server;
        Thread Client_Listener, Client_Handler;
        public Server(gamemain infos)
        {
            Serialiseur = new BinaryFormatter();
            Infos = infos;
            try
            {
                port = 9580;
                server = new TcpListener(new IPEndPoint(IPAddress.Any, port));
                server.Start();
                Client_Listener = new Thread(new ThreadStart(StartConnexion));
                Client_Listener.Start();

            }
            catch (SocketException e)
            {
                Console.WriteLine("erreur" + e.Message);
            }
        }
        
        public void StartConnexion()
        {

            while (true)
            {
                Client = server.AcceptTcpClient();
                Client_Handler = new Thread(new ParameterizedThreadStart(Receiver));
                Client_Handler.Start(Client);
            }

        }
        
        public void Ping()
        {
            if (Client.Client.Poll(-1, SelectMode.SelectError))
            {
                Client.Close();
                server.Stop();
                Client_Listener.Abort();
                Client_Handler.Abort();
                Console.WriteLine("Le Client distant s'est deconnecté");
            }
        }

        public void Receiver(object client)
        {
            TcpClient Sender = (TcpClient)client;
            while (true)
            {

                NetworkStream SentStream = Sender.GetStream();
               Infos = (Templar.gamemain)Serialiseur.Deserialize(SentStream);

            }
        }

        public void Parser(int type, int info)
        {
            switch (type)
            {
                case 1:
                    Infos.player.chgt_position(info, (int)Infos.player.position_player.Y);
                    break;

                default:
                    break;
            }
        }

        public void Send(NetworkStream file)
        {
            file = new NetworkStream(Client.Client);
            Serialiseur.Serialize(file, Infos);
        }
    }
}
