using Application.DTOs.Profile;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IProfile
    {
        Task<ProfileResponse> GetProfile(ProfileDTO profileDTO);
    }
}
