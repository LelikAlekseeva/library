using Microsoft.AspNetCore.SignalR;

namespace library.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Receive", user, message);
        }
    }
}
