using Application.DTOs.PersonalProfile.About;
using Application.DTOs.PersonalProfile.Age;
using Application.DTOs.PersonalProfile.Country;
using Application.DTOs.PersonalProfile.Info;
using Application.DTOs.PersonalProfile.Twitch;

namespace Application.Contract.PersonalProfile
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IInfo
    {
        Task<InfoResponse> GetInfo(InfoDTO infoDTO);
        Task<TwitchResponse> SetTwitch(TwitchDTO twitchDTO);
        Task<CountryResponse> SetCountry(CountryDTO countryDTO);
        Task<AgeResponse> SetAge(AgeDTO ageDTO);
        Task<AboutResponse> SetAbout(AboutDTO aboutDTO);
    }
}
