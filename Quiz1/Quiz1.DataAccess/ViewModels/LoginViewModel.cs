using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.DataAccess.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Remote("DoesEmailExistWhenLogin", "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}
