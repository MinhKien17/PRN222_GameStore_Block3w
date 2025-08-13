using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }

    public class RegisterRequest
    {
        [Required, EmailAddress]
        public string email { get; set; } = null!;

        [Required, MinLength(4)]
        public string password { get; set; } = null!;

        [Required, Compare("password", ErrorMessage = "Passwords do not match.")]
        public string confirmPassword { get; set; } = null!;
    }
    public class UserDTO
    {
        public int? Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
