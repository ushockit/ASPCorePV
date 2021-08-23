using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Hubs
{
    public class ChatMessage
    {
        public string Username { get; set; }
        public string Message { get; set; }
    }
    public class ConnectedClient
    {
        public string ConnectionId { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        public int Id { get; set; }
    }
    public class ChatHub : Hub
    {
        IHttpContextAccessor _httpContextAccessor;
        string authUsername;
        ApplicationDbContext db;

        static List<ConnectedClient> connectedClients = new List<ConnectedClient>();
        static int counter = 0;
        public ChatHub(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            authUsername = _httpContextAccessor.HttpContext.User.Identity.Name;
            this.db = db;
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            ++counter;
            var user = db.Users.First(u => u.Email.Equals(authUsername));

            var client = new ConnectedClient
            {
                ConnectionId = Context.ConnectionId,
                Id = user.Id,
                Username = user.Email,
            };

            connectedClients.Add(client);

            await Clients.Caller.SendAsync("personalUserInfo", client);
            await Clients.Caller.SendAsync("usersList", connectedClients);
            await Clients.AllExcept(Context.ConnectionId).SendAsync("newUserConnected", client);

            if (counter <= 2)
                await Groups.AddToGroupAsync(Context.ConnectionId, "demo");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);

            connectedClients.Remove(connectedClients.FirstOrDefault(client => client.Username.Equals(authUsername)));
            if (counter <= 2)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "demo");
        }

        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }

        public async Task SendGroupMessage(ChatMessage message)
        {
            await Clients.Group("demo").SendAsync("receiveMessage", message);
        }
    }
}
