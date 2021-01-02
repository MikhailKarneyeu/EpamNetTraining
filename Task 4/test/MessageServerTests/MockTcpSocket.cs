using MessageServer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MessageServerTests
{
    class MockTcpSocket : ISocket
    {
        public ISocket MockSocket { get; set; }
        public int counter;
        public ISocket Accept(string address, int port)
        {
            return MockSocket;
        }

        public bool Connect(string address, int port)
        {
            return true;
        }

        public void Disconnect()
        {
        }

        public EndPoint GetEndpoint()
        {
            return new IPEndPoint(IPAddress.Parse("1.1.1.1"), 1);
        }

        public bool IsConnected()
        {
            return true;
        }

        public string Receive()
        {
            if (counter < 0)
            {
                throw new SocketException();
            }
            else if (counter < 2)
            {
                counter++;
                return "mock message фыва";
            }
            return "";
        }

        public bool Send(string message)
        {
            return true;
        }
    }
}
