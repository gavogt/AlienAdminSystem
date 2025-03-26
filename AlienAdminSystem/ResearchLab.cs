using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class ResearchLab : Facility
    {
        public int LabEquipmentCount { get; set; }

        public ResearchLab()
        {
            
        }

        public override ValidationResult ValidateBooking(Booking booking)
        {
            if (booking.NumberOfVisitors < LabEquipmentCount)
                return new ValidationResult { IsValid = true, Message = $"Booking is valid the Number of Visitors #{booking.NumberOfVisitors} is less than the Lab Equipment Count #{LabEquipmentCount}."};
            return new ValidationResult { IsValid = false, Message = $"Booking is invalid the Number of Visitors #{booking.NumberOfVisitors} is greater than the Lab Equipment Count #{LabEquipmentCount}."};
        }
    }
}
