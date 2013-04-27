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
        gamemain infos;
        private int port;
        int type = 0;
        TcpClient Client;
        TcpListener server;
        Thread Client_Listener, Client_Handler;
        NetworkStream Sentstream;
        public Server()
        {
            Serialiseur = new BinaryFormatter();
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
            bool isrunnin = true;
            while (isrunnin)
            {
                Client = server.AcceptTcpClient();
                Client_Handler = new Thread(new ParameterizedThreadStart(Receiver));
                Client_Handler.Start(Client);
            }
        }

        public bool Ping()
        {
            if (Client.Client.Poll(-1, SelectMode.SelectError))
            {
                Client.Close();
                server.Stop();
                Client_Listener.Abort();
                Client_Handler.Abort();
                Console.WriteLine("Le Client distant s'est deconnecté");
                return false;
            }
            return true;
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
            if (Sentstream.DataAvailable)
            {
                type = BR.ReadInt32();
                switch (type)
                {
                    case 1:
                        Infos.same_map = (Infos.map.x == BR.ReadInt32() && Infos.map.y == BR.ReadInt32());
                        break;
                    case 2:
                        Infos.player2.chgt_position(BR.ReadInt32(), BR.ReadInt32());
                        
                        break;
                    case 31:    
                        Infos.List_Sort.RemoveAt(BR.ReadInt32());
                        BR.ReadInt32();
                        break;
                    case 32:
                        int transit = BR.ReadInt32();
                        Infos.player2.Sort_selec = transit;
                        if (transit == 1)
                        {
                            Infos.List_Sort.Add(new sort(ressource.boule_de_feu, Infos.player2));
                        }
                        else
                        {
                            Infos.List_Sort.Add(new sort(ressource.glace, Infos.player2));
                        }
                        BR.ReadInt32();
                        break;
                    case 41:
                        Infos.List_Zombie.RemoveAt(BR.ReadInt32());
                        BR.ReadInt32();
                        break;
                    case 42:
                        Infos.List_Zombie.Add(new NPC(24, 32, 4, 2, 1, 15, Infos.position_npc, ressource.zombie, Infos.player, Infos));
                        BR.ReadInt32();
                        BR.ReadInt32();
                        break;
                }

                if (Sentstream.DataAvailable)
                {
                    Parser(Infos);
                }
            }
        }

        public void Send(int type, int a, int b)
        {
            BinaryWriter BW = new BinaryWriter(Client.GetStream());
            BW.Write(type);
            BW.Write(a);
            BW.Write(b);
        }
        public void Send(int type, object value)
        {
            Serialiseur.Serialize(Client.GetStream(), value);
        }
    }
}
