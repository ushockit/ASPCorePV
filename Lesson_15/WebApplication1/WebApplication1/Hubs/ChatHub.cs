using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Hubs
{
    public class ChatMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }
    }
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var ctx = Context;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
