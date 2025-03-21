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
            new Facility { FacilityID = 1, FacilityName = "Galactic Infirmary Quarantine Zone" },
            new Facility { FacilityID = 2, FacilityName = "Celestial Containment Facility" },
            new Facility { FacilityID = 3, FacilityName = "Interplanetary Peace Center" },
            new Facility { FacilityID = 4, FacilityName = "Stellar Harmony Embassy" },
            new Facility { FacilityID = 5, FacilityName = "Cosmic Unity Consulate" },
            new Facility { FacilityID = 6, FacilityName = "Galactic Sciences Division – Earth Sector" },
            new Facility { FacilityID = 7, FacilityName = "Quantum Tech & Energy Research Facility" },
            new Facility { FacilityID = 8, FacilityName = "Cosmic Terraforming & Environmental Adaptation Center" }
        };
    }
}
