using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Runtime.Serialization;

namespace Templar
{
    class Client
    {
        int type = 0; // int permettant de savoir de quel champ on parle (position/vie etc...)
        TcpClient client;        
        Thread Client_Listener;
        NetworkStream Sentstream;

        public Client(string address)
        {
            
            try
            {
                Int32 port = 9580;
                client = new TcpClient(address, port);
                Client_Listener = new Thread(new ThreadStart(Receive));//Ce thread permet de recevoir en permanence
                Client_Listener.Start();
            }
            catch (SocketException e)
            {
                client.Close();
                Console.WriteLine("SocketException: {0}", e);
            }

           // Console.WriteLine("\n Press Enter to continue...");
          //  Console.Read();
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
