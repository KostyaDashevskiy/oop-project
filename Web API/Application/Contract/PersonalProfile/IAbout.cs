using Application.DTOs.PersonalProfile.About;

namespace Application.Contract.PersonalProfile
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IAbout
    {
        Task<AboutResponse> SetAbout(AboutDTO aboutDTO);
    }
}
