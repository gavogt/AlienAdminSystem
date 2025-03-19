﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class Alien
    {
        [Required(ErrorMessage = "Alien First Name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alien Last Name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alien Planet is required.")]
        public string Planet { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alien Species is required.")]
        public string Species { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alien Email is required.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alien Age is required.")]
        public int Age { get; set; } = 0;

        [Required(ErrorMessage = "Alien Age is required.")]
        public int SelectedGroupID { get; set; } = 0;


        public Alien(string firstName, string lastName, string planet, string species, string email, int age, int selectedGroupID)
        {
            FirstName = firstName;
            LastName = lastName;
            Planet = planet;
            Species = species;
            Email = email;
            Age = age;
            SelectedGroupID = selectedGroupID;

        }
    }
}
