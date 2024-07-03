using Application.DTOs.PersonalProfile.Country;

namespace Application.Contract.PersonalProfile
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface ICountry
    {
        Task<CountryResponse> SetCountry(CountryDTO countryDTO);
    }
}
