using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Common;

namespace MultiClient
{
    class Program
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private const int PORT = 100;

        static void Main()
        {
            Console.Title = "Client";
            ConnectToServer();
            RequestLoop();
            Exit();
        }

        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(IPAddress.Loopback, PORT);
                }
                catch (SocketException) 
                {
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Connected");
        }

        private static void RequestLoop()
        {
            Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");

            Task t1 = new Task(new Action(ReceiveResponse));
            t1.Start();
            
            while (true)
            {
                SendRequest();
                //ReceiveResponse();
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        private static void Exit()
        {
            SendString("exit"); // Tell the server we are exiting
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        private static void SendRequest()
        {

            Console.Write("Send a request: ");
            string request = Console.ReadLine();
            SendString(request);

            if (request.ToLower() == "exit")
            {
                Exit();
            }
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private static void SendObject(string text)
        {
            List<NetPacket> lists = new List<NetPacket>();
            NetPacket n1 = new NetPacket();
            n1.Name = text;
            NetPacket n2 = new NetPacket();
            n2.Name = "BBBB";
            lists.Add(n1);
            lists.Add(n2);

            BinaryFormatter bin = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();

            bin.Serialize(memoryStream, n1);

            byte[] dataBytes = memoryStream.ToArray();
            ClientSocket.Send(dataBytes);


            //BinaryFormatter bin = new BinaryFormatter();
            //MemoryStream mem = new MemoryStream();
            //bin.Serialize(mem, lists);
            //ClientSocket.Send(mem.GetBuffer(), mem.GetBuffer().Length, SocketFlags.None);

            //byte[] buffer = Encoding.ASCII.GetBytes(text);
            //ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private static void ReceiveResponse()
        {
            while (true)
            {
                var buffer = new byte[2048];
                int received = ClientSocket.Receive(buffer, SocketFlags.None);
                if (received == 0) return;
                var data = new byte[received];
                Array.Copy(buffer, data, received);
                string text = Encoding.ASCII.GetString(data);
                Console.WriteLine(text);
                Thread.Sleep(100);
            }
        }
    }
}
