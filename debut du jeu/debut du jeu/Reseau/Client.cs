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
        IPAddress address;
        TcpClient client;
        TcpListener server;
        Thread Client_thread;
        NetworkStream stream;

        public Client()
        {
            try
            {
                int Type;
                Int32 port = 4242;
                Client_thread = new Thread(new ThreadStart(StartConnexion));       
            }
            catch (SocketException e)
            {
                client.Close();
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }

        public void StartConnexion()
        {
            client.Connect(address, port);
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
            stream = client.GetStream();
            BinaryReader clientStreamReader = new BinaryReader(stream);
            
            while (true)
            {
                clientStreamReader.Read();
            }
            stream.Close();
        }

        public void Send()
        {
            stream = client.GetStream();
            BinaryWriter clientStreamWriter = new BinaryWriter(stream);

            while (true)
            {
               // clientStreamWriter
            }
            stream.Close();
        }
    }

}
