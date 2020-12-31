using MessageServer;
using NickBuhro.Translit;
using System;

namespace MessageHangling
{
    public class ClientMessageHandler : IClientMessageHandler
    {
        public string LastMessage { get; private set; }
        public string HandleMessage(string message)
        {
            message = Transliteration.CyrillicToLatin(message, Language.Russian);
            LastMessage = message;
            return message;
        }
    }
}
