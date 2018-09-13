using AsyncTcp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using UnityEngine;

public class testConnectToServer : MonoBehaviour {
    AsyncTcpClient client;
    // Use this for initialization
    void Start () {
        ConneectStart();

    }
    void ConneectStart()
    {
        client = new AsyncTcpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
        client.ServerDisconnected += new EventHandler<TcpServerDisconnectedEventArgs>(client_ServerDisconnected);
        client.PlaintextReceived += new EventHandler<TcpDatagramReceivedEventArgs<string>>(client_PlaintextReceived);
        client.ServerConnected += new EventHandler<TcpServerConnectedEventArgs>(client_ServerConnected);

        client.Connect();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
        {
            client.Send("hello you!");
        }
	}

    void client_ServerConnected(object sender, TcpServerConnectedEventArgs e)
    {
        Debug.Log("连接服务端成功" + System.Environment.NewLine);

    }

    void client_PlaintextReceived(object sender, TcpDatagramReceivedEventArgs<string> e)
    {
        if (e.Datagram != "Received")
        {

            Debug.Log(string.Format("Server : {0} --> ",e.TcpClient.Client.RemoteEndPoint.ToString()) + string.Format("{0}", e.Datagram));
        }

    }

    void client_ServerDisconnected(object sender, TcpServerDisconnectedEventArgs e)
    {
        Debug.Log(string.Format(CultureInfo.InvariantCulture,
            "TCP server {0} has disconnected.",
            e.ToString()));
    }
}
