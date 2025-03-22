using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class FacilityRepository
    {
            public static List<Facility> ListAllFacilities() => new List<Facility>
        {
            new Facility { ID = 1, Name = "Galactic Infirmary Quarantine Zone" },
            new Facility { ID = 2, Name = "Celestial Containment Facility" },
            new Facility { ID = 3, Name = "Interplanetary Peace Center" },
            new Facility { ID = 4, Name = "Stellar Harmony Embassy" },
            new Facility { ID = 5, Name = "Cosmic Unity Consulate" },
            new Facility { ID = 6, Name = "Galactic Sciences Division – Earth Sector" },
            new Facility { ID = 7, Name = "Quantum Tech & Energy Research Facility" },
            new Facility { ID = 8, Name = "Cosmic Terraforming & Environmental Adaptation Center" }
        };
    }
}
