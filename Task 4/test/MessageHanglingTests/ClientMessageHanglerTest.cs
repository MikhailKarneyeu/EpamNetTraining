using NUnit.Framework;
using MessageHandling;

namespace MessageHanglingTests
{
    public class ClientMessageHanglerTests
    {
        [Test]
        public void HandleMessageTest()
        {
            //Arrange
            ClientMessageHandler messageHandler = new ClientMessageHandler();
            string message = "éöóêåíãøùçõÔÛÂÀÏĞÎËÄÆİß×ÑÌÈÒÁŞ";
            string assertMessage = "jczukengshshhzxFY`VAPROLDZhE`YaChSMITBYu";
            //Act
            messageHandler.HandleMessage(message);
            //Assert
            Assert.IsTrue(assertMessage.Equals(messageHandler.GetLastMessage()));
        }
    }
}