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

namespace Server
{
    public partial class Form1 : Form
    {
        AsyncTcpServer server;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = new AsyncTcpServer(9999);
            server.ClientConnected +=
              new EventHandler<TcpClientConnectedEventArgs>(server_ClientConnected);
            server.ClientDisconnected +=
              new EventHandler<TcpClientDisconnectedEventArgs>(server_ClientDisconnected);
            server.PlaintextReceived +=
              new EventHandler<TcpDatagramReceivedEventArgs<string>>(server_PlaintextReceived);
            server.Start();
            textBox1.AppendText("服务端启动" + System.Environment.NewLine);

        }

        void server_ClientConnected(object sender, TcpClientConnectedEventArgs e)
        {
            textBox1.BeginInvoke((MethodInvoker)delegate
            {
                textBox1.AppendText(string.Format(CultureInfo.InvariantCulture,
                "TCP client {0} has connected.",
                e.TcpClient.Client.RemoteEndPoint.ToString()) + System.Environment.NewLine);
            });

        }

        void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
        {
            textBox1.BeginInvoke((MethodInvoker)delegate
            {
                textBox1.AppendText(string.Format(CultureInfo.InvariantCulture,
                "TCP client {0} has disconnected.",
                e.TcpClient.Client.RemoteEndPoint.ToString()) + System.Environment.NewLine);
            });

        }

        void server_PlaintextReceived(object sender, TcpDatagramReceivedEventArgs<string> e)
        {
            if (e.Datagram != "Received")
            {
                textBox1.BeginInvoke((MethodInvoker)delegate
                {
                    textBox1.AppendText(string.Format("Client : {0} --> ",
                  e.TcpClient.Client.RemoteEndPoint.ToString()));
                    textBox1.AppendText(string.Format("{0}", e.Datagram) + System.Environment.NewLine);
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.SendAll(textBox2.Text);
            textBox2.Text = "";

        }

    }
}
