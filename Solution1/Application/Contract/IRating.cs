using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract
{
    public enum RatigStatus{
        Victory,
        Defeat,
        Draw,
        Show
    }
    public interface IRating
    {
        Task<RatingResponse> ManipulateMMR(RatingDTO ratingDTO, RatigStatus status);
    }
}
