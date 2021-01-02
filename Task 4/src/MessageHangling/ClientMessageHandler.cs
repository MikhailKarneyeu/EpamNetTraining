using MessageServer;
using NickBuhro.Translit;
using System;

namespace MessageHandling
{
    public class ClientMessageHandler : IClientMessageHandler
    {
        private string lastMessage;

        public string GetLastMessage()
        {
            return lastMessage;
        }

        public string HandleMessage(string message)
        {
            message = Transliteration.CyrillicToLatin(message, Language.Russian);
            lastMessage = message;
            return message;
        }
    }
}
