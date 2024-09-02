namespace WebAPI.Online.Models
{
    public interface IGameClient
    {
        public Task ReceiveMessage(string userName, string message);
    }
}
