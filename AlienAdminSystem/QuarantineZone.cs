﻿using AlienAdminSystem.Platforms.Tizen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class QuarantineZone : IFacility
    {
        public int FacilityID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FacilityName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int FacilityStatus { get; set; }
        public int FacilityCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EnvironmentSettings EnvironmentControls { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}
