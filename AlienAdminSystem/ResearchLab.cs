using AlienAdminSystem.Platforms.Tizen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class ResearchLab : IFacility
    {
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public int FacilityStatus { get; set; }
        public int FacilityCapacity { get; set; }
        public EnvironmentSettings EnvironmentControls { get; set; }

        public ResearchLab(string facilityName, int facilityStatus, int capacity, decimal radiationLevel, decimal lightingLevel)
        {
            FacilityName = facilityName;
            FacilityCapacity = capacity;
            EnvironmentControls = new EnvironmentSettings
            {
                RadiationLevel = radiationLevel,
                LightingLevel = lightingLevel
            };

        }
    }
}
