﻿using System.ComponentModel.DataAnnotations;

namespace Project_5.Models.Home
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
        
        public bool RememberMe { get; set; }
    }
}