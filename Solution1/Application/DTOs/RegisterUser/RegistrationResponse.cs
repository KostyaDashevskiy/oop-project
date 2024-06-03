using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RegisterUser
{
    //класс определяет какие поля мы передаем в ответе на РЕГИСТРАЦИЮ
    public record RegistrationResponse(int code, string Message = null!);

}
