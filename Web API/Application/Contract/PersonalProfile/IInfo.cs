using Application.DTOs.PersonalProfile.Info;

namespace Application.Contract.PersonalProfile
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IInfo
    {
        Task<InfoResponse> GetInfo(InfoDTO infoDTO);
    }
}
