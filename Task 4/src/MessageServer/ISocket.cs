using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageServer
{
    public interface ISocket
    {
        EndPoint GetEndpoint();
        bool IsConnected();
        ISocket Accept(string address, int port);
        string Receive();
        bool Send(string message);
        void Disconnect();
        bool Connect(string address, int port);
    }
}
