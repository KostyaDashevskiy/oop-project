using Application.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface ICountry
    {
        Task<CountryResponse> SetCountry(CountryDTO countryDTO);
    }
}
