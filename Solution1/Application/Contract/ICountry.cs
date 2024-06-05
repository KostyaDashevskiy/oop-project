using Application.DTOs.Country;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface ICountry
    {
        Task<CountryResponse> SetCountry(CountryDTO countryDTO);
    }
}
