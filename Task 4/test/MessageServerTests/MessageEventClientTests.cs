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
    class MessageEventClientTests
    {
        [Test]
        public void ConnectTest()
        {
            //Arrange
            MockTcpSocket mockSocket = new MockTcpSocket();
            MessageEventClient client = new MessageEventClient(mockSocket);
            mockSocket.MockSocket = mockSocket;
            mockSocket.counter = 0;
            //Act
            //Assert
            Assert.IsTrue(client.Connect("1.1.1.1", 1));
            mockSocket.counter = -1;
        }

        [Test]
        public void SendMessageTest()
        {
            //Arrange
            MockTcpSocket mockSocket = new MockTcpSocket();
            MessageEventClient client = new MessageEventClient(mockSocket);
            mockSocket.MockSocket = mockSocket;
            mockSocket.counter = 0;
            //Act
            client.Connect("1.1.1.1", 1);
            //Assert
            Assert.IsTrue(client.SendMessage("message"));
            mockSocket.counter = -1;
        }

        [Test]
        public void AddMessageHandlerTest()
        {
            //Arrange
            MockTcpSocket mockSocket = new MockTcpSocket();
            MessageEventClient client = new MessageEventClient(mockSocket);
            mockSocket.MockSocket = mockSocket;
            mockSocket.counter = 0;
            ClientMessageHandler messageHandler = new ClientMessageHandler();
            client.AddMessageHandler(messageHandler);
            string message = "mock message фыва";
            string assertMessage = "mock message fy`va";
            //Act
            messageHandler.HandleMessage(message);
            //Assert
            Thread.Sleep(1000);
            Assert.IsTrue(assertMessage.Equals(client.MessageHandlers[0].GetLastMessage()));
            mockSocket.counter = -1;
        }
    }
}
