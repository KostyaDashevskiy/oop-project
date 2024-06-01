using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RatingDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
