using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageServer
{
    public interface IServerMessageHandler
    {
        public Dictionary<EndPoint, List<string>> GetMessageDictionary();
        void HandleMessage(string message, EndPoint socket);
    }
}
