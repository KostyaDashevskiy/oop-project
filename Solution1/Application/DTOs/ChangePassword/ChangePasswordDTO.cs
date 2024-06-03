using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ChangePassword
{
    //класс определяет какие поля мы получаем в запросе на СМЕНУ ПАРОЛЯ
    public class ChangePasswordDTO
    {
        public string UserName { get; set; } = default!;
        public string OldPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!;

    }
}
