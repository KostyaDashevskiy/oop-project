using Application.DTOs.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IInfo
    {
        Task<InfoResponse> GetInfo(InfoDTO infoDTO);
    }
}
