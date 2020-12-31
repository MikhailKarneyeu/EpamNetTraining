using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace MessageServer
{
    public class MessageServer
    {
        private delegate void MessageHandler(string message, EndPoint endPoint);
        private event MessageHandler MessageEvent;
        private readonly ISocket socket;
        private readonly object _lock = new object();
        public List<IServerMessageHandler> MessageHandlers { get; private set; }
        public List<ISocket> Clients { get; private set; }
        public MessageServer()
        {
            MessageHandlers = new List<IServerMessageHandler>();
            Clients = new List<ISocket>();
        }

        public void Accept(string address, int port)
        {
            while (true)
            {
                ISocket connectedSocket = socket.Accept(address, port);
                lock (_lock) Clients.Add(connectedSocket);
                Thread t = new Thread(ClientHandler);
                t.Start(connectedSocket);
            }
        }

        private void ClientHandler(object o)
        {
            string message;
            ISocket client;
            lock (_lock) client = o as ISocket;
            while (true)
            {
                message = client.Receive();
                MessageEvent.Invoke(message, client.GetEndpoint());
            }
            lock (_lock) Clients.Remove(client);
            client.Disconnect();
        }

        public void SendMessageAll(string message)
        {
            lock (_lock)
            {
                foreach (ISocket client in Clients)
                {
                    client.Send(message);
                }
            }
        }

        public void SendMessageById(int id, string message)
        {
            lock (_lock)
            {
                Clients[id].Send(message);
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
