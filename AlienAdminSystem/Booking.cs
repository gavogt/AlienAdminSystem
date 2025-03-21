﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public int FacilityID { get; set; }
        public int AlienID { get; set; }

        [Range(0, 10, ErrorMessage = "Number of visitors must be between 0 and 10.")]
        public int NumberOfVisitors { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Start time is required.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        public DateTime EndTime { get; set; }

    }
}
