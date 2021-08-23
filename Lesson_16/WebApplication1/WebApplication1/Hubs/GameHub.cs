using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Hubs
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class GameHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
           
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task Move(Coord coord)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("move", coord);
        }
    }
}
