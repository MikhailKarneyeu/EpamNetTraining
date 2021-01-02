using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MessageServer
{
    public class MessageEventClient
    {
        private delegate string MessageHandler(string message);
        private event MessageHandler MessageEvent;
        private readonly ISocket _socket;
        private Thread thread;
        public List<IClientMessageHandler> MessageHandlers { get; private set; }
        public MessageEventClient(ISocket socket)
        {
            MessageHandlers = new List<IClientMessageHandler>();
            _socket = socket;
        }
        public bool Connect(string address, int port)
        {
            bool result = _socket.Connect(address, port);
            thread = new Thread(o => ReceiveMessage((ISocket)o));
            thread.Start(_socket);
            return result;
        }

        public void Disconnect()
        {
            thread.Join();
            _socket.Disconnect();
        }

        private void ReceiveMessage(ISocket socket)
        {
            try
            {
                while (true)
                {
                    string message;
                    message = socket.Receive();
                    if (message != null)
                    {
                        MessageEvent?.Invoke(message);
                    }
                }
            }
            catch(SocketException)
            { }
        }

        public bool SendMessage(string message)
        {
            if (_socket.IsConnected())
            {
                _socket.Send(message);
                return true;
            }
            return false;
        }

        public void AddMessageHandler(IClientMessageHandler handler)
        {
            MessageHandlers.Add(handler);
            MessageEvent += (string message) => handler.HandleMessage(message);
        }
    }
}
