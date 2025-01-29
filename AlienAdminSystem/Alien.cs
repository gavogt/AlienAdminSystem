using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class Alien
    {
        [Required(ErrorMessage = "Alien Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alien Planet is required.")]
        public string Planet { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        [Range(1, 9999, ErrorMessage = "Age must be between 1 and 9999.")]
        public int Age { get;} = 0;

        public static int counter = 1;

        public Alien(string name, string planet, int age)
        {
            Name = name;
            Planet = planet;
            Age = age;

            Image = $"images/alien{counter}";

            counter++;
        }
    }
}
