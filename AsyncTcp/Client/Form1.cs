using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsyncTcp;
using System.Globalization;
using System.Net;

namespace Client
{
    public partial class Form1 : Form
    {
        AsyncTcpClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new AsyncTcpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            client.ServerDisconnected += new EventHandler<TcpServerDisconnectedEventArgs>(client_ServerDisconnected);
            client.PlaintextReceived += new EventHandler<TcpDatagramReceivedEventArgs<string>>(client_PlaintextReceived);
            client.ServerConnected += new EventHandler<TcpServerConnectedEventArgs>(client_ServerConnected);

        }

        void client_ServerConnected(object sender, TcpServerConnectedEventArgs e)
        {
            textBox3.BeginInvoke((MethodInvoker)delegate {
                textBox3.AppendText("连接服务端成功" + System.Environment.NewLine);
            });

        }

        void client_PlaintextReceived(object sender, TcpDatagramReceivedEventArgs<string> e)
        {
            if (e.Datagram != "Received")
            {
                textBox3.BeginInvoke((MethodInvoker)delegate
                {
                    textBox3.AppendText(string.Format("Server : {0} --> ",
                  e.TcpClient.Client.RemoteEndPoint.ToString()));
                    textBox3.AppendText(string.Format("{0}", e.Datagram) + System.Environment.NewLine);
                });
            }

        }

        void client_ServerDisconnected(object sender, TcpServerDisconnectedEventArgs e)
        {
            textBox3.BeginInvoke((MethodInvoker)delegate
            {
                textBox3.AppendText(string.Format(CultureInfo.InvariantCulture,
                "TCP server {0} has disconnected.",
                e.ToString()) + System.Environment.NewLine);
            });

        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.Connect();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            client.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            client.Send(textBox4.Text);
            textBox4.Text = "";

        }
    }
}
