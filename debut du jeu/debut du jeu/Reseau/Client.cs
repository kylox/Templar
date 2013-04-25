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
        IFormatter Serialiseur;
        TcpClient client;        
        Thread Client_Listener;
        NetworkStream SentStream;
        gamemain Infos;

        public Client(string address)
        {
            
            try
            {
                Int32 port = 4242;
                client = new TcpClient(new IPEndPoint(IPAddress.Parse(address), port));
                client.Connect(address, port);
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
           byte[] Number = new byte[2];           
            while (true)
            {
                SentStream = client.GetStream();
            }
        }

        public void Parser(gamemain Infos)
        {
            BinaryReader BR = new BinaryReader(SentStream);
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
                    Infos.List_Sort.Add((Templar.sort)Serialiseur.Deserialize(SentStream));
                    break;
                case 41:
                    Infos.List_Zombie.RemoveAt(BR.ReadInt32());
                    break;
                case 42:
                    Infos.List_Zombie.Add((Templar.NPC)Serialiseur.Deserialize(SentStream));
                    break;


            }
        }

        public void Send(NetworkStream file)
        {
            file = new NetworkStream(client.Client);
            Serialiseur.Serialize(file, Infos);
        }
    }

}
