using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem.Platforms.Tizen
{
    internal interface IFacility
    {
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }

        public string FacilityStatus { get; set; }

        public int FacilityCapacity { get; set; }

        public EnvironmentSettings EnvironmentControls { get; set; }

    }
}
