using library.Migrations;
using Microsoft.AspNetCore.SignalR;
using Moq;
using library.Hubs;
using library.Models;

namespace library.Tests.UnitTests.Hubs
{
    public class EBookHubTests
    {
        [Fact]
        public async Task SendBookUpdate_ShouldSendMessageToAllClients()
        {
            // Arrange
            var hub = new BookHub();

            var clientsMock = new Mock<IHubCallerClients>();
            var clientProxyMock = new Mock<IClientProxy>();

            clientsMock.Setup(c => c.All).Returns(clientProxyMock.Object);

            hub.Clients = clientsMock.Object;

            var book = new ElectronicAudioBook
            {
                Title = "Test Book",
                Genre = "ужасы",
                Language = "Чучунский"
            };

            // Act
            await hub.SendBookUpdate(book);

            // Assert
            clientProxyMock.Verify(
                c => c.SendCoreAsync(
                    "BookUpdated",
                    It.Is<object[]>(o => o.Length == 1 && o[0] == book),
                    default
                ),
                Times.Once
            );
        }
    }
}
