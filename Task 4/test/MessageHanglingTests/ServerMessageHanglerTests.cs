using MessageHandling;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MessageHanglingTests
{
    public class ServerMessageHanglerTests
    {
        [Test]
        public void HandleMessageTest()
        {
            //Arrange
            ServerMessageHandler messageHandler = new ServerMessageHandler();
            string[] messages = new string[3] { "message 1", "message 2", "message 3" };
            EndPoint[] endPoints = new IPEndPoint[3] {new IPEndPoint(IPAddress.Parse("1.1.1.1"), 1), new IPEndPoint(IPAddress.Parse("1.1.1.1"), 1), new IPEndPoint(IPAddress.Parse("1.1.1.2"), 1), };
            Dictionary<EndPoint, List<string>> assertDictionary = new Dictionary<EndPoint, List<string>>
            {
                { endPoints[0], new List<string>() { messages[0], messages[1] } },
                { endPoints[2], new List<string>() { messages[2] } }
            };
            var assertDictionaryKeys = assertDictionary.Keys.ToList();
            //Act
            messageHandler.HandleMessage(messages[0], endPoints[0]);
            messageHandler.HandleMessage(messages[1], endPoints[1]);
            messageHandler.HandleMessage(messages[2], endPoints[2]);
            //Assert
            Assert.IsTrue(assertDictionaryKeys.All(key => messageHandler.GetMessageDictionary().ContainsKey(key) && assertDictionary[key].SequenceEqual(messageHandler.GetMessageDictionary()[key])));
        }
    }
}