using AsyncTcp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyAsyncServer
{
    class MyServer
    {
        AsyncTcpServer server;
        List<EndPoint> PlayerList;
        public MyServer()
        {
            PlayerList = new List<EndPoint>();
        }

        public void StartServer()
        {
            server = new AsyncTcpServer(9999);
            server.ClientConnected +=
              new EventHandler<TcpClientConnectedEventArgs>(server_ClientConnected);
            server.ClientDisconnected +=
              new EventHandler<TcpClientDisconnectedEventArgs>(server_ClientDisconnected);
            server.PlaintextReceived +=
              new EventHandler<TcpDatagramReceivedEventArgs<string>>(server_PlaintextReceived);
            server.Start();
            Console.WriteLine("服务端启动");
        }

        void server_ClientConnected(object sender, TcpClientConnectedEventArgs e)
        {

            Console.WriteLine(string.Format(CultureInfo.InvariantCulture,
                "TCP client {0} has connected.",
                e.TcpClient.Client.RemoteEndPoint.ToString()));
            PlayerList.Add(e.TcpClient.Client.RemoteEndPoint);

            NotifyNewPlayerEnter(e);
        }

        void NotifyNewPlayerEnter(TcpClientConnectedEventArgs e)
        {
            PlayerProfile playerProfile = new PlayerProfile();
            playerProfile.endPoint = e.TcpClient.Client.RemoteEndPoint.ToString();
            string json1 = JsonConvert.SerializeObject(playerProfile);
            Console.WriteLine(json1);
            server.SendAll("NewPlayer|");
        }

        void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
        {
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture,
                "TCP client {0} has disconnected.",
                e.TcpClient.Client.RemoteEndPoint.ToString()));
        }

        void server_PlaintextReceived(object sender, TcpDatagramReceivedEventArgs<string> e)
        {
            if (e.Datagram != "Received")
            {

                Console.WriteLine(string.Format("Client : {0} --> ",
                  e.TcpClient.Client.RemoteEndPoint.ToString()));
                Console.WriteLine(string.Format("{0}", e.Datagram));
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyServer server = new MyServer();
            server.StartServer();

            Console.ReadLine();
        }
    }
}
