using MessageHandling;
using MessageServer;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MessageServerTests
{
    public class MessageEventServerTests
    {
        [Test]
        public void AcceptTest()
        {
            //Arrange
            MockTcpSocket mockSocket = new MockTcpSocket();
            MessageEventServer server = new MessageEventServer(mockSocket);
            mockSocket.MockSocket = mockSocket;
            mockSocket.counter = 0;
            //Act
            server.Accept("1.1.1.1", 1);
            //Assert
            Assert.IsTrue(server.Clients[0].Equals(mockSocket));
            mockSocket.counter = -1;
        }

        [Test]
        public void SendMessageTest()
        {
            //Arrange
            MockTcpSocket mockSocket = new MockTcpSocket();
            MessageEventServer server = new MessageEventServer(mockSocket);
            mockSocket.MockSocket = mockSocket;
            mockSocket.counter = 0;
            //Act
            server.Accept("1.1.1.1", 1);
            //Assert
            Assert.IsTrue(server.SendMessageAll("test message"));
            mockSocket.counter = -1;
        }

        [Test]
        public void SendMessageByIdTest()
        {
            //Arrange
            MockTcpSocket mockSocket = new MockTcpSocket();
            MessageEventServer server = new MessageEventServer(mockSocket);
            mockSocket.MockSocket = mockSocket;
            mockSocket.counter = 0;
            //Act
            server.Accept("1.1.1.1", 1);
            //Assert
            Assert.IsTrue(server.SendMessageById(0, "test message"));
            mockSocket.counter = -1;
        }


        [Test]
        public void AddMessageHandlerTest()
        {
            //Arrange
            MockTcpSocket mockSocket = new MockTcpSocket();
            MessageEventServer server = new MessageEventServer(mockSocket);
            mockSocket.MockSocket = mockSocket;
            mockSocket.counter = 0;
            ServerMessageHandler messageHandler = new ServerMessageHandler();
            server.AddMessageHandler(messageHandler);
            Dictionary<EndPoint, List<string>> assertDictionary = new Dictionary<EndPoint, List<string>>
            {
                { new IPEndPoint(IPAddress.Parse("1.1.1.1"), 1), new List<string>() { "mock message פûגא", "mock message פûגא" } }
            };
            var assertDictionaryKeys = assertDictionary.Keys.ToList();
            //Act
            server.Accept("1.1.1.1", 1);
            //Assert
            Thread.Sleep(1000);
            Assert.IsTrue(assertDictionaryKeys.All(key => messageHandler.GetMessageDictionary().ContainsKey(key) && assertDictionary[key].SequenceEqual(messageHandler.GetMessageDictionary()[key])));
            mockSocket.counter = -1;
        }
    }
}