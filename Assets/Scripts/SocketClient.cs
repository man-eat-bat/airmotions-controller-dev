using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SocketClient : MonoBehaviour
{
    // Start is called before the first frame update
    static private Socket sockfd;
    

    private const string HOST1 = "192.168.0.102";
    private const string HOST2 = "192.168.8.100";
    private const string HOST3 = "192.168.1.5";
    private const int PORT = 5628;
   
    void Start()
    {
        
        sockfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        IAsyncResult result = sockfd.BeginConnect(HOST1, PORT, null, null);
        bool success = result.AsyncWaitHandle.WaitOne(300, true);
        
        if (sockfd.Connected)
        {
            sockfd.EndConnect(result);
            return;
        }
        result = sockfd.BeginConnect(HOST2, PORT, null, null);
        success = result.AsyncWaitHandle.WaitOne(300, true);
        if (sockfd.Connected)
        {
            sockfd.EndConnect(result);
            return;
        }
        result = sockfd.BeginConnect(HOST3, PORT, null, null);
        success = result.AsyncWaitHandle.WaitOne(300, true);
        if (sockfd.Connected)
        {
            sockfd.EndConnect(result);
            return;
        }
    }

    // Update is called once per frame
    static public void Send(string arg)
    {
        SocketClient.Send(Encoding.ASCII.GetBytes(arg));
    }
    static public void Send(byte[] arg)
    {
        sockfd.Send(arg);
    }
    void Update()
    {
       
    }
}
