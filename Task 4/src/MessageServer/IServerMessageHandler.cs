using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageServer
{
    public interface IServerMessageHandler
    {
        void HandleMessage(string message, EndPoint socket);
    }
}
