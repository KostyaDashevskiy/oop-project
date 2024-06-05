﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ChangePassword
{
    //класс определяет какие поля мы получаем в запросе на СМЕНУ ПАРОЛЯ
    public class ChangePasswordDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string OldPassword { get; set; } = default!;

        [Required]
        public string NewPassword { get; set; } = default!;

    }
}
