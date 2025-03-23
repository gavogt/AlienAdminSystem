using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    public enum Species
    {
        Reptilian,
        [Display(Name = "Time Traveler")]
        TimeTraveler,
        Grey,
        Hybrid,
    }
}
