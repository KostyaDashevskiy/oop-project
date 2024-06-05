using Application.DTOs.Info;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IInfo
    {
        Task<InfoResponse> GetInfo(InfoDTO infoDTO);
    }
}
