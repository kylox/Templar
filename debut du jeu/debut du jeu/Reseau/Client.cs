using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;

namespace Templar.Reseau
{
    class Client
    {
        private int port;
        int Type; // int permettant de savoir de quel champ on parle (position/vie etc...)
        TcpClient client;
        TcpListener server;
        Thread Client_Listener;
        NetworkStream stream;

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

                NetworkStream SentStream = client.GetStream();
                if (Type == 0)
                {

                    Type = BitConverter.ToInt32(Number, 0);
                }
                else
                {
                    // Méthode remplissant les champs
                }

            }
        }

        public void Send()
        {
            BinaryWriter clientStreamWriter = new BinaryWriter(client.GetStream());

            while (true)
            {
               // clientStreamWriter.Write
            }
        }
    }

}
