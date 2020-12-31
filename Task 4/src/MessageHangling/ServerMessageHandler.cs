using MessageServer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageHangling
{
    public class ServerMessageHandler : IServerMessageHandler
    {
        public Dictionary<EndPoint, List<string>> Messages { get; private set; }
        public void HandleMessage(string message, EndPoint endPoint)
        {
            if (Messages.ContainsKey(endPoint))
                Messages[endPoint].Add(message);
            else 
                Messages.Add(endPoint, new List<string>() { message });
        }
    }
}
