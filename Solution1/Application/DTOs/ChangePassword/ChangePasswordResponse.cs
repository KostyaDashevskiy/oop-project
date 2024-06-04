using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ChangePassword
{
    //класс определяет какие поля мы передаем в ответе на СМЕНУ ПАРОЛЯ
    public record ChangePasswordResponse(int Code, string Message);
}
