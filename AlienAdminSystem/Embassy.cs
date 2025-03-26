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

        public override ValidationResult ValidateBooking(Booking booking)
        {

            if (booking.Aliens == null || !booking.Aliens.Any())
            {
                return new ValidationResult { IsValid = false, Message = "No aliens in booking" };
            }

            bool valid = booking.Aliens.All(alien => alien.AtmosphereTypeID == RequiredAtmosphereTypeID);

            return new ValidationResult { IsValid = valid, Message = valid ? $"Booking {booking.ID} is valid with required atmosphere type {RequiredAtmosphereTypeID}" : $"Booking {booking.ID} is not valid with required atmosphere type {RequiredAtmosphereTypeID}" };

        }
    }
}
