using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal interface IFacility
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } 

        // Common Properties
        public string Description { get; set; } 
        //public EnvironmentalControlSettings EnvironmentalControls { get; set; } 
        public int Capacity { get; set; }
        public Status Status { get; set; }


        // Foreign Key
        public int FacilityTypeID { get; set; } 

        // Foreign Key
        public int AtmosphereTypeID { get; set; } 
    }
}
