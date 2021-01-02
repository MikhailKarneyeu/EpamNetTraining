using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MessageServer
{
    public class MessageEventServer
    {
        private delegate void MessageHandler(string message, EndPoint endPoint);
        private event MessageHandler MessageEvent;
        private readonly ISocket _socket;
        private readonly object _lock = new object();
        public List<IServerMessageHandler> MessageHandlers { get; private set; }
        public List<ISocket> Clients { get; private set; }
        public MessageEventServer(ISocket socket)
        {
            _socket = socket;
            MessageHandlers = new List<IServerMessageHandler>();
            Clients = new List<ISocket>();
        }

        public void Accept(string address, int port)
        {
            ISocket connectedSocket = _socket.Accept(address, port);
            lock (_lock) Clients.Add(connectedSocket);
            Thread t = new Thread(ClientHandler);
            t.Start(connectedSocket);
        }

        private void ClientHandler(object o)
        {
            string message;
            ISocket client;
            lock (_lock) client = o as ISocket;
            try
            {
                while (true)
                {
                    message = client.Receive();
                    if (message != "")
                        MessageEvent?.Invoke(message, client.GetEndpoint());
                }
            }
            catch(SocketException)
            {
                lock (_lock) Clients.Remove(client);
                client.Disconnect();
            }
        }

        public bool SendMessageAll(string message)
        {
            bool result = true;
            lock (_lock)
            {
                foreach (ISocket client in Clients)
                {
                    if (!client.Send(message))
                        result = false;
                }
            }
            return result;
        }

        public bool SendMessageById(int id, string message)
        {
            lock (_lock)
            {
                return Clients[id].Send(message);
            }
        }

        public void AddMessageHandler(IServerMessageHandler handler)
        {
            MessageHandlers.Add(handler);
            MessageEvent += delegate (string message, EndPoint endPoint)
            {
                handler.HandleMessage(message, endPoint);
            };
        }
    }
}
