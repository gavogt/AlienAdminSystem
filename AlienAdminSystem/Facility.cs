using System;
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
        public string Name { get; set; } = string.Empty;

        // Common Properties
        public string Description { get; set; } = string.Empty;
        public EnvironmentalControlSettings EnvironmentalControls { get; set; } = new EnvironmentalControlSettings();
        public int Capacity { get; set; } = 0;
        public string SpecialRequirements { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        // Foreign Key
        public int FacilityTypeID { get; set; } = 0;
        // Foreign Key
        public int AtmosphereTypeID { get; set; } = 0;

        // Abstract method to be implemented by derived classes (Embassy, Research Lab, etc.)
        public abstract bool ValidateBooking(Booking booking);

    }
}
