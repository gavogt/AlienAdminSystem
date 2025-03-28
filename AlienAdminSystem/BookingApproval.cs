using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    public class BookingApproval
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingApprovalID { get; set; }

        // Common Properties
        public int? AdminID { get; set; }
        public bool IsApproved { get; set; }
        public BookingStatus.Status ApprovalStatus { get; set; } = BookingStatus.Status.AutoApproved;
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        // EF navigation
        public Booking? Booking { get; set; }


    }
}
