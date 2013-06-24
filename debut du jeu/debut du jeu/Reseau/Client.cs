using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Runtime.Serialization.Formatters.Binary;

namespace Templar
{
    public class Client
    {
        IFormatter Serialiseur;
        int type = 0; // int permettant de savoir de quel champ on parle (position/vie etc...)
        public TcpClient client;        
        Thread Client_Listener;
        NetworkStream Sentstream;

        public Client(string address)
        {
            Serialiseur = new BinaryFormatter();
            try
            {
                Int32 port = 9580;
                client = new TcpClient(address, port);
                Client_Listener = new Thread(new ThreadStart(Receive));//Ce thread permet de recevoir en permanence
                Client_Listener.Start();
            }
            catch (SocketException e)
            {
               // client.Close();
                Console.WriteLine("SocketException: {0}", e);
            }

           // Console.WriteLine("\n Press Enter to continue...");
          //  Console.Read();
        }
        public void StopConnexion()
        {
            Sentstream.Close();
            client.Close();
            Client_Listener.Abort();
        }
        public void ping()
        {
            try
            {
                if (client.Client.Poll(-1, SelectMode.SelectError))
                {
                    client.Close();
                    Console.WriteLine("Déconnxion");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

        }

        public void Receive()
        {        
            while (true)
            {
                Sentstream = client.GetStream();
            }
        }
        public Donjon ReceiveDungeon()
        {
            Thread.Sleep(500);
            MemoryStream m = new MemoryStream();
            Donjon sol = new Donjon();
            Sentstream = client.GetStream();
            BinaryReader t;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    t = new BinaryReader(Sentstream);
                    if (t.ReadInt32() == 1)
                    {
                        Map transit = new Map();
                        transit.Coffres = /*(Templar.Coffre[,])*/Serialiseur.Deserialize(Sentstream) as Templar.Coffre[,];
                        transit.colision = (int[,])Serialiseur.Deserialize(Sentstream);
                        transit.mob = (Vector2[,])Serialiseur.Deserialize(Sentstream);
                        transit.monstre = (List<NPC>)Serialiseur.Deserialize(Sentstream);
                        transit.objet = (Vector2[,])Serialiseur.Deserialize(Sentstream);
                        transit.tiles = (Vector2[,])Serialiseur.Deserialize(Sentstream);
                        transit.Tilelist = (Tile[,])Serialiseur.Deserialize(Sentstream);
                        sol.Map[i, j] = transit;
                    }
                    else
                        sol.Map[i, j] = null;
                }
            }
            sol.map = (Vector2) Serialiseur.Deserialize(client.GetStream());
            sol.position_J = (Vector2)Serialiseur.Deserialize(client.GetStream());
            return sol;
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
                        switch (BR.ReadInt32())
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
            BinaryWriter BW = new BinaryWriter(client.GetStream());
            BW.Write(type);
            BW.Write(a);
            BW.Write(b);
        }
    }

}
