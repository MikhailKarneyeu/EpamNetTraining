using System;
using System.Collections.Generic;
using System.Text;

namespace MessageServer
{
    public interface IClientMessageHandler
    {
        string HandleMessage(string message);
    }
}
