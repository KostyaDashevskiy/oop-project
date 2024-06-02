using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record RegisterUserDTO()
    {
        [Required]
        public string? Name { get; set; } = string.Empty;//поле

        [Required, EmailAddress]
        public string? Email { get; set; } = string.Empty;//поле

        [Required]
        public string? Password { get; set; } = string.Empty;//поле

        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; } = string.Empty;//поле
    }
}
