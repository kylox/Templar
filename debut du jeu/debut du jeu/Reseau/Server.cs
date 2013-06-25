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
    public class Server
    {
        IFormatter Serialiseur;
        private int port;
        int type = 0;
        public TcpClient Client;
        TcpListener server;
        Thread Client_Listener, Client_Handler;
        NetworkStream Sentstream;
        public bool isrunnin;
        public Server()
        {
            Serialiseur = new BinaryFormatter();
            try
            {
                isrunnin = true;
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
        public void SendDungeon(Donjon donj)
        {
            Sentstream = Client.GetStream();
            BinaryWriter t = new BinaryWriter(Sentstream);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (donj.Map[i, j] != null)
                    {
                        t.Write(1);
                        Serialiseur.Serialize(Sentstream, donj.Map[i, j].Coffres);
                        Serialiseur.Serialize(Sentstream, donj.Map[i, j].colision);
                        Serialiseur.Serialize(Sentstream, donj.Map[i, j].mob);
                        t.Write(donj.Map[i, j].monstre.Count);
                        foreach (NPC q in donj.Map[i, j].monstre)
                        {
                            t.Write(q.frameline);
                            Serialiseur.Serialize(Sentstream, q.position);
                        }
                        Serialiseur.Serialize(Sentstream, donj.Map[i, j].objet);
                        Serialiseur.Serialize(Sentstream, donj.Map[i, j].tiles);
                        Serialiseur.Serialize(Sentstream, donj.Map[i, j].Tilelist);
                    }
                    else
                    {
                        t.Write(0);
                    }
                }
            }
            Serialiseur.Serialize(Sentstream, donj.map);
            Serialiseur.Serialize(Sentstream, donj.position_J);
        }
        public void StartConnexion()
        {
            // isrunnin = true;
            while (isrunnin)
            {
                Client = server.AcceptTcpClient();
                Client_Handler = new Thread(new ParameterizedThreadStart(Receiver));
                Client_Handler.Start(Client);
                isrunnin = false;
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

        public void StopConnexion()
        {
            Client.Close();
            server.Stop();
            Client_Listener.Abort();
            Client_Handler.Abort();
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
                    case 11:
                        int t = BR.ReadInt32();
                        switch (t)
                        {
                            case 3:
                                Infos.player2.direction = Direction.Up;
                                Infos.player2.ChangeFrameline(3);
                                break;
                            case 1:
                                Infos.player2.direction = Direction.Down;
                                Infos.player2.ChangeFrameline(1);
                                break;
                            case 2:
                                Infos.player2.direction = Direction.Left;
                                Infos.player2.ChangeFrameline(2);
                                break;
                            case 4:
                                Infos.player2.direction = Direction.Right;
                                Infos.player2.ChangeFrameline(4);
                                break;
                            case 0:
                                Infos.player2.direction = Direction.None;
                                Infos.player2.ChangeFrameline(Infos.player.Frame_start);
                                Infos.player2.timer = 0;
                                break;
                        }
                        BR.ReadInt32();
                        break;
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
                        Infos.List_Zombie.Add(new NPC(24, 32, 4, 2, 1, 15, 8, Infos.position_npc, ressource.zombie, Infos.player, Infos.map.Active_Map));
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
