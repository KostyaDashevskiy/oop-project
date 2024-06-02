﻿using Application.Contract;
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
        public string UserName { get; set; } = default!;

        [Required]
        public RatigStatus status { get; set; } = default!;
    }
}
