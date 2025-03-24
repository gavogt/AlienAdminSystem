using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class Embassy : Facility
    {
        public int RequiredAtmosphereTypeID { get; set; } = 1;

        public override bool ValidateBooking(Booking booking)
        {
            // If booking Atmosphere Type is Oxygen return true;
            if(booking.Aliens == null)
            {
                return false; // No aliens to validate
            }
            return booking.Aliens.All(alien => alien.AtmosphereTypeID == RequiredAtmosphereTypeID); 

        }
    }
}
