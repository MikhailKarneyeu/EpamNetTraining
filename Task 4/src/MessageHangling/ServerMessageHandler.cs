using MessageServer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageHandling
{
    public class ServerMessageHandler : IServerMessageHandler
    {
        public ServerMessageHandler()
        {
            messages = new Dictionary<EndPoint, List<string>>();
        }
        private Dictionary<EndPoint, List<string>> messages;

        public Dictionary<EndPoint, List<string>> GetMessageDictionary()
        {
            return messages;
        }

        public void HandleMessage(string message, EndPoint endPoint)
        {
            if (messages.ContainsKey(endPoint))
                messages[endPoint].Add(message);
            else 
                messages.Add(endPoint, new List<string>() { message });
        }
    }
}
