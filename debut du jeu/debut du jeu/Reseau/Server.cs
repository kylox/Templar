using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Templar
{
    class Server
    {
        IFormatter Serialiseur;
        gamemain Infos;
        private int port;
        int type = 0;
        TcpClient Client;
        TcpListener server;
        Thread Client_Listener, Client_Handler;
        NetworkStream Sentstream;
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
                Sentstream = Sender.GetStream();
            }
        }

        public void Parser(gamemain Infos)
        {
            BinaryReader BR = new BinaryReader(Sentstream);
            type = BR.ReadInt32();
            switch (type)
            {
                case 2:
                    Infos.player.chgt_position(BR.ReadInt32(), BR.ReadInt32());
                    break;
                case 31:
                    Infos.List_Sort.RemoveAt(BR.ReadInt32());
                    break;
                case 32:
                    Infos.List_Sort.Add((Templar.sort)Serialiseur.Deserialize(Sentstream));
                    break;
                case 41:
                    Infos.List_Zombie.RemoveAt(BR.ReadInt32());
                    break;
                case 42:
                    Infos.List_Zombie.Add((Templar.NPC)Serialiseur.Deserialize(Sentstream));
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
