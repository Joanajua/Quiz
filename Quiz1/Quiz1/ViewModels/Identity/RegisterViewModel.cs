using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.ViewModels.Identity
{
    public class RegisterViewModel
    {
        /// <summary>
        /// If wanted to add a domain validation add the following attribute specifying the required domain
        /// e.g. [ValidEmailDomain(allowedDomain: "mailinator.com", ErrorMessage = "Email domain must be mailinator.com")]
        /// </summary>
        [Required]
        [EmailAddress]
        [Remote("IsEmailInUseWhenRegister", "Account" )]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
