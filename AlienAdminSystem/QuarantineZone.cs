using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class QuarantineZone : Facility
    {
        public bool IsAccessible { get; set; } = false;

        public override ValidationResult ValidateBooking(Booking booking)
        {

            return new ValidationResult { IsValid = IsAccessible, Message = $"Facility ID: {booking.FacilityID} is a Quarantine Zone and is not accessible" };

        }
    }
}
