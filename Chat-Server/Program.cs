using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Net;

namespace Chat_Server
{
    class Program
    {
        
        public static Hashtable clientsList = new Hashtable();

        public static void Main(string[] args)
        {
            TcpListener server = null;
            TcpClient client = default(TcpClient);
            try
            {
                Int32 port = 7777;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");	//server IP
                server = new TcpListener(localAddr, port);

                int counter = 0;
                
                server.Start();

                // buffer for receiving data
                Byte[] bytes = new Byte[256];
                String data = null;
            
                Console.WriteLine(" Server Chat process started ");

                // server listening loop to clients
                while ((true))
                {
                client = server.AcceptTcpClient();
                counter += 1;

                //reading data sent by the client
                NetworkStream stream = client.GetStream();
                stream.Read(bytes, 0, bytes.Length);
                data = System.Text.Encoding.ASCII.GetString(bytes);
                data = data.Substring(0, data.IndexOf("$"));

                //adding the client to the client list
                clientsList.Add(data, client);

				//invio della notifica ai client che un nuovo client si è unito alla chat
                broadcast(data + " enter the chat ", data, false);
                Console.WriteLine(data + " enter the chat ");
				
				//avvio del thread per la gestione del client
                handleClinet clieent = new handleClinet();
                clieent.startClient(client, data);
                
                }

            client.Close();
            server.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();

            } catch(SocketException e)
            {

            }
        }

        // function for sending data to all clients
        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " : " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }  
    }

    //class for managing the client process
    public class handleClinet
    {
        private TcpClient clientSocket;
        private string clNo;
        private Thread ctThread;

        //function for starting the thread for managing the client
        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;

            ctThread = new Thread(doChat);
            ctThread.Start();

        }

        public void endClient()
        {
            this.clientSocket.Close();
            this.ctThread.Abort();
        }

        // function for client management
        private void doChat()
        {	
            int requestCount = 0;
            byte[] bytesFrom = new byte[256];
            string dataFromClient = null;
            string rCount = null;
            requestCount = 0;
			
            NetworkStream networkStreamm = clientSocket.GetStream();
            networkStreamm.Read(bytesFrom, 0, bytesFrom.Length);
            dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
            dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
            Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
            rCount = Convert.ToString(requestCount);

            Program.broadcast(dataFromClient, clNo, true);

            while (dataFromClient != (clNo + " exit chat"))
                {
                    try
                    {
                        requestCount = requestCount + 1;
                        NetworkStream networkStream = clientSocket.GetStream();
                        networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                        dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                        dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                        Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                        rCount = Convert.ToString(requestCount);

                        Program.broadcast(dataFromClient, clNo, true);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }

                }     
            networkStreamm.Close();
            Program.clientsList.Remove(clNo);
            endClient();
        }
    }
}