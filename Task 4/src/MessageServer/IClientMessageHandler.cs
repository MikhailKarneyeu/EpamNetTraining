using System;
using System.Collections.Generic;
using System.Text;

namespace MessageServer
{
    public interface IClientMessageHandler
    {
        public string GetLastMessage();
        string HandleMessage(string message);
    }
}
