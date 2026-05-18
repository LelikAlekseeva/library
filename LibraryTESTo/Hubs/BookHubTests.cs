using library.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library.Hubs;
using Moq;

namespace LibraryTESTo.Hubs
{
    public class BookHubTests
    {
        [Fact]
        public async Task SendTicketUpdate_ShouldSendMessageToAllClients()
        {
            // Arrange
            var hub = new BookHub();

            var clientsMock = new Mock<IHubCallerClients>();
            var clientProxyMock = new Mock<IClientProxy>();

            clientsMock.Setup(c => c.All).Returns(clientProxyMock.Object);

            hub.Clients = clientsMock.Object;

            var E_Book = new E_Book
            {
                Title = "Test Book",
                Language = "Английский",
                Genre = "Комедия"
            };

            // Act
            await hub.SendTicketUpdate(E_Book);

            // Assert
            clientProxyMock.Verify(
                c => c.SendCoreAsync(
                    "E_bookUpdated",
                    It.Is<object[]>(o => o.Length == 1 && o[0] == E_Book),
                    default
                ),
                  Times.Once
            );
        }
    }
}