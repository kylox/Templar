using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Templar.Reseau
{
    class Server
    {
        
        gamemain Infos;
        int Type = 0;
        private int port;
        TcpClient Client;
        TcpListener server;
        Thread Client_Listener, Client_Handler;
        public Server(gamemain infos)
        {
            Infos = infos;
            try
            {
                port = 4242;
                server = new TcpListener(new IPEndPoint(IPAddress.Any, port));
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
            server.Start();
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
            byte[] Number = new byte[2];
            TcpClient Sender = (TcpClient)client;
            while (true)
            {
                
                NetworkStream SentStream = Sender.GetStream();
                if (Type == 0)
                {

                    Type = BitConverter.ToInt32(Number, 0);
                }
                else
                {

                }

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

        public void Send(NetworkStream file, int type)
        {
            byte[] FileType = BitConverter.GetBytes(type);
            byte[] File = new byte[file.Length];
            file.Read(File, 0, (int)file.Length);
            Client.Client.Send(FileType);
            Client.Client.Send(File);
        }
    }
}
