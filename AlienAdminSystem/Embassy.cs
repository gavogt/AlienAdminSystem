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
            if (booking.BookingApprovalID == 2)
            {
                booking.BookingApprovalID = 2;
                return new ValidationResult { IsValid = false, Message = $"Booking {booking.ID} is not auto-approved" };
            }

            if (booking.Aliens == null || !booking.Aliens.Any())
            {
                booking.BookingApprovalID = 3;
                return new ValidationResult { IsValid = false, Message = $"Booking {booking.ID} has no aliens" };
            }

            bool valid = booking.Aliens.All(alien => alien.AtmosphereTypeID == RequiredAtmosphereTypeID);
            if (!valid)
            {
                booking.BookingApprovalID = 3;
                return new ValidationResult { IsValid = false, Message = $"Booking {booking.ID} is not valid with required atmosphere type {RequiredAtmosphereTypeID}" };
            }

            return new ValidationResult { IsValid = true, Message = $"Booking {booking.ID} is valid with required atmosphere type {RequiredAtmosphereTypeID}" };

        }
    }
}
