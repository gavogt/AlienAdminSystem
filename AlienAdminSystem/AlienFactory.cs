using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal static class AlienFactory
    {
        public static Alien CreateAlien(string firstName, string lastName, string planet, Species species, string email, int age, int selectedGroupID, int atmosphereType, int visitDurationMonths, string specialRequirements)
        {
            return species switch
            {
                Species.TimeTraveler => new TimeTraveler(firstName, lastName, planet, species, email, age, selectedGroupID, atmosphereType, visitDurationMonths, specialRequirements)
                {
                },

                Species.Reptilian => new Reptilian(firstName, lastName, planet, species, email, age, selectedGroupID, atmosphereType, visitDurationMonths, specialRequirements)
                { 
                },
                Species.Grey => new Grey(firstName, lastName, planet, species, email, age, selectedGroupID, atmosphereType, visitDurationMonths, specialRequirements)
                {
                },

                Species.Hybrid => new Hybrid(firstName, lastName, planet, species, email, age, selectedGroupID, atmosphereType, visitDurationMonths, specialRequirements)
                {
                },
                _ => throw new ArgumentException("Invalid alien species type.", nameof(species))

            };

        }
    }
}
