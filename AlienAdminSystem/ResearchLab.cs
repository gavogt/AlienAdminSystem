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
        public int FacilityID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FacilityName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FacilityStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int FacilityCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EnvironmentSettings EnvironmentControls { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ResearchLab(string facilityName, int capacity, decimal radiationLevel, decimal lightingLevel)
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
