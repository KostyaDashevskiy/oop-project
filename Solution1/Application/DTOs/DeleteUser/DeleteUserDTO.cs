using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.DeleteUser
{
    //класс определяет какие поля мы получаем в запросе на УДАЛЕНИЕ ПОЛЬЗОВАТЕЛЯ
    public class DeleteUserDTO
    {
        [Required]
        public string UserName { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
