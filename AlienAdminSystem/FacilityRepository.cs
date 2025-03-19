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
                new ResearchLab("Galactic Sciences Division – Earth Sector", 1,100, 500.0m, 400.0m),
                new ResearchLab("Quantum Tech & Energy Research Facility",1, 200, 600.0m, 500.0m),
                new ResearchLab("Cosmic Terraforming & Environmental Adaptation Center", 0, 300, 700.0m, 600.0m),

            };
        }
    }
}
