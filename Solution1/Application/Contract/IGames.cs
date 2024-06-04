﻿using Application.DTOs.Rating;
using Application.DTOs.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    //шаблон класса, здесь определяются какие методы будет реализовать данный класс, какие запросы обрабатывать
    public interface IGames
    {
        Task<StatisticsResponse> GetStatistics(StatisticsDTO statisticsDTO);
    }
}
