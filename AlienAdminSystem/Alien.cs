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
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Planet { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public int SelectedGroupID { get; set; } = 0;
        public int AtmosphereType { get; set; } = 0;
        public string SpecialRequirements { get; set; } = string.Empty;
        public int VisitDurationMonths { get; set; } = 0;


        public Alien(string firstName, string lastName, string planet, string species, string email, int age, int selectedGroupID, int atmosphereType, string specialRequirements, int visitDurationMonths)
        {
            FirstName = firstName;
            LastName = lastName;
            Planet = planet;
            Species = species;
            Email = email;
            Age = age;
            SelectedGroupID = selectedGroupID;
            AtmosphereType = atmosphereType;
            SpecialRequirements = specialRequirements;
            VisitDurationMonths = visitDurationMonths;


        }
    }
}
