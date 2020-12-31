using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageServer
{
    public class TcpSocket : ISocket
    {
        private readonly Socket socket;
        public EndPoint lastEndPoint;
        public bool IsConnected()
        {
            return socket.Connected;
        }
        public TcpSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public TcpSocket(Socket connectedSocket)
        {
            socket = connectedSocket;
        }

        public ISocket Accept(string address, int port)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(ipPoint);
            listenSocket.Listen(10);
            ISocket connectedSocket = new TcpSocket(listenSocket.Accept());
            return connectedSocket;
        }

        public bool Connect(string address, int port)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            socket.Connect(ipPoint);
            return socket.Connected;
        }

        public void Disconnect()
        {
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }

        public string Receive()
        {
            StringBuilder message = new StringBuilder();
            byte[] data = new byte[1024];
            int bytes;
            do
            {
                bytes = socket.ReceiveFrom(data, SocketFlags.None, ref lastEndPoint);
                message.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            return message.ToString();
        }

        public bool Send(string message)
        {
            if (socket.Connected)
            {
                byte[] data;
                data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);
                return true;
            }
            return false;
        }

        public EndPoint GetEndpoint()
        {
            return lastEndPoint;
        }
    }
}
