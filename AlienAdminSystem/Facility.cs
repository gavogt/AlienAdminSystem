﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal abstract class Facility : IFacility
    {
        [Key]
        public int ID { get; set; }

        // Common Properties
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;    
        public int Capacity { get; set; } = 0;
        public FacilityStatus Status { get; set; }

        // Foreign Key
        public int FacilityTypeID { get; set; } = 0;
        // Foreign Key
        public int AtmosphereTypeID { get; set; } = 0;

        // Navigation Properties
        public FacilityType? FacilityType { get; set; }
        public AtmosphereType? AtmosphereType { get; set; }

        // Owned Entity Properties
        public EnvironmentalControlSettings EnvironmentalControls { get; set; } = new EnvironmentalControlSettings();

        // Abstract method to be implemented by derived classes (Embassy, Research Lab, etc.)
        public abstract ValidationResult ValidateBooking(Booking booking);

    }
}
