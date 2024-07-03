using Application.DTOs.PersonalProfile.Age;

namespace Application.Contract.PersonalProfile
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IAge
    {
        Task<AgeResponse> SetAge(AgeDTO ageDTO);
    }
}
