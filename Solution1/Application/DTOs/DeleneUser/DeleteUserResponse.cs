using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.DeleneUser
{
    //класс определяет какие поля мы передаем в ответе на УДАЛЕНИЕ ПОЛЬЗОВАТЕЛЯ
    public record DeleteUserResponse(int code, string Message);
}
