using Application.DTOs.PersonalProfile.Twitch;

namespace Application.Contract.PersonalProfile
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface ITwitch
    {
        Task<TwitchResponse> SetTwitch(TwitchDTO twitchDTO);
    }
}
