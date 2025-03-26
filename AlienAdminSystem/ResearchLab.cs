﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class ResearchLab : Facility
    {
        public int LabEquipmentCount { get; set; }

        private static readonly Random _random = new Random();

        public ResearchLab()
        {
            
        }

        public override bool ValidateBooking(Booking booking)
        {
            if (booking.NumberOfVisitors < LabEquipmentCount) 
                return false;
            return true;
        }
    }
}
