using Application.DTOs.Twitch;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface ITwitch
    {
        Task<TwitchResponse> SetTwitch(TwitchDTO twitchDTO);
    }
}
