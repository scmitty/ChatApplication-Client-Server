using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client
{
    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        NetworkStream serverStream = default(NetworkStream);

        string readData = null;

        Thread ctThread = null;
        public Form1()
        {
            InitializeComponent();
        }

        public void connect_btn_Click(object sender, EventArgs e)
        {
            if(usernameChat_txb.Text=="")
            {
                MessageBox.Show("Insert a Username");
                return;
            }
            readData = "Try Connection to Chat ...";
            msg();
            try
            {
                clientSocket.Connect("127.0.0.1", 7777);

                //send username to Server
                serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(usernameChat_txb.Text + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                //thread start, a process that initiates a continuous reading of messages by the server
                connection_btn.Enabled = false;
                usernameChat_txb.ReadOnly = true;
                ctThread = new Thread(getMessage);
                ctThread.Start();
            }catch(Exception)
            {
                readData = "Connection Fail...";
                msg();
            }
        }

        private void sendMsg_btn_Click(object sender, EventArgs e)
        {
            //sending the message to the server
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(msg_txb.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            msg_txb.Text = "";
            msg_txb.Focus();

        }

        private void getMessage()
        {
            //continuous reading process of messages sent by the server
            while (true)
            {
                serverStream = clientSocket.GetStream();
                byte[] inStream = new byte[256];
                serverStream.Read(inStream, 0, inStream.Length);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }

        }

        private void msg()
        {
            //print the message inside the form
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                chat_txb.Text = chat_txb.Text + Environment.NewLine + " >> " + readData;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            //sending a message to the server announcing the exit from the chat
            serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(usernameChat_txb.Text + " exit chat" + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            serverStream.Close();

            clientSocket.Close();

            ctThread.Abort();

            this.Close();
        }

        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            //sending a message to the server announcing the exit from the chat
            serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(usernameChat_txb.Text + " exit chat" + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            serverStream.Close();

            clientSocket.Close();

            ctThread.Abort();

            Application.Restart();
        }

    }
}
