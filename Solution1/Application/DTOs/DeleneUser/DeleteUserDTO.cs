﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.DeleneUser
{
    //класс определяет какие поля мы получаем в запросе на УДАЛЕНИЕ ПОЛЬЗОВАТЕЛЯ
    public class DeleteUserDTO
    {
        public string Name { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}