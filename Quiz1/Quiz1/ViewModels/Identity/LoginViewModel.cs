﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Quiz1.ViewModels.Identity
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
