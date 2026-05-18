using library.Migrations;
using Microsoft.AspNetCore.SignalR;
using library.Models;

namespace StudentLibrary2.Hubs
{
    public class BookHub : Hub
    {
        // Отправка обновления книги всем клиентам
        public async Task SendBookUpdate(ElectronicAudioBook book)
        {
            await Clients.All.SendAsync("BookUpdated", book);
        }
    }
}
