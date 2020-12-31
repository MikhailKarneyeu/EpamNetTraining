using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MessageServer
{
    public class MessageClient
    {
        private delegate string MessageHandler(string message);
        private event MessageHandler MessageEvent;
        private readonly ISocket socket;
        private Thread thread;
        public List<IClientMessageHandler> MessageHandlers { get; private set; }
        public void Connect(string address, int port)
        {
            socket.Connect(address, port);
            thread = new Thread(o => ReceiveMessage((ISocket)o));
            thread.Start(socket);
        }

        public void Disconnect()
        {
            thread.Join();
            socket.Disconnect();
        }

        private void ReceiveMessage(ISocket socket)
        {
            string message;
            message = socket.Receive();
            MessageEvent.Invoke(message);
        }

        public void SendMessage(string message)
        {
            if (socket.IsConnected())
                socket.Send(message);
        }

        public void AddMessageHandler(IClientMessageHandler handler)
        {
            MessageHandlers.Add(handler);
            MessageEvent += (string message) => handler.HandleMessage(message);
        }
    }
}
