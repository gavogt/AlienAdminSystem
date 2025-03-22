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

        public override bool ValidateBooking(Booking booking)
        {
            if (!IsAccessible)
                return false;

            return true;
        }
    }
}
