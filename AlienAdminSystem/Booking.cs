using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int FacilityID { get; set; }

        [Range(0, 10, ErrorMessage = "Number of visitors must be between 0 and 10.")]
        public int NumberOfVisitors { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        //public Alien? Alien { get; set; }

        public List<Alien> Aliens { get; set; } = new List<Alien>();

        // Foreign Key
        public int UserID { get; set; }

        // EF Navigation
        public User? User { get; set; }



    }
}
