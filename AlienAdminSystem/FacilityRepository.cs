using AlienAdminSystem.Platforms.Tizen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class FacilityRepository
    {
        public List<IFacility> GetFacilities()
        {
            return new List<IFacility>
            {
                new ResearchLab("Alien Research Lab", 100, 500.0m, 400.0m),
                new ResearchLab("New Species Research Lab", 200, 600.0m, 500.0m),
                new ResearchLab("Advanced Research Lab", 300, 700.0m, 600.0m),

            };
        }
    }
}
