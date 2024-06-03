using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    //класс определяет какие поля мы передаем в ответе на ЛОГИН
    public record LoginResponse(int code, string Message = null!, string Token = null!);

}
