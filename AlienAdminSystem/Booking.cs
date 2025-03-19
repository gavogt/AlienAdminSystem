using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int FacilityID { get; set; }
        public int AlienID { get; set; }
        public int VisitDuration { get; set; }
        public int NumberOfVisitors { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now.AddHours(1);

    }
}
