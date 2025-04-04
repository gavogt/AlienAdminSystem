﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class SignUpModel
    {

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = String.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = String.Empty;
        [Required(ErrorMessage = "Confirm Password is required.")]

        public Species Species { get; set; }

        public string ConfirmPassword { get; set; } = String.Empty;

        public SignUpModel()
        {

        }

        public SignUpModel(string username, string password, Species species, string confirmPassword)
        {
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
