using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebAPI.Online.Models;

namespace WebAPI.Online.Hubs
{
    public class GameHub : Hub<IGameClient>
    {
        private readonly IDistributedCache cache;

        public GameHub(IDistributedCache distributedCache)
        {
            cache = distributedCache;
        }

        public async Task JoinGame(GameModel connection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.GameId);

            var stringConnection = JsonSerializer.Serialize(connection);

            await cache.SetStringAsync(Context.ConnectionId, stringConnection);

        }

        public async Task MakeMove(string cardId)
        {
            var stringConnection = await cache.GetAsync(Context.ConnectionId);
            var connection = JsonSerializer.Deserialize<GameModel>(stringConnection);

            if (connection is not null)
            {
                await Clients
                    .Group(connection.GameId)
                    .ReceiveMessage(connection.PlayerName, cardId);
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var stringConnection = await cache.GetAsync(Context.ConnectionId);
            var connection = JsonSerializer.Deserialize<GameModel>(stringConnection);

            if (connection is not null)
            {
                await cache.RemoveAsync(Context.ConnectionId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.GameId);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
