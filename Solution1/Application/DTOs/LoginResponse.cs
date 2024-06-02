﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record LoginResponse(int code, string Message = null!, string Token = null! ); //поля в ответе
    //применение в Infrastructure\Repo\UserRepo

}
