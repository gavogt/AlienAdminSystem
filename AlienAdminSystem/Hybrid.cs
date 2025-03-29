using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class Hybrid : Alien
    {
        public Hybrid(string firstName, string lastName, string planet, Species species, string email, int age, int alienGroupID, int atmosphereTypeID, int visitDurationMonths, string specialRequirements) : base(firstName, lastName, planet, species, email, age, alienGroupID, atmosphereTypeID, visitDurationMonths, specialRequirements)
        {
        }

        public Hybrid()
        {
            
        }
    }
}
