using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AlienAdminSystem
{
    public enum Status
    {
        Open,
        [Display(Name = "Under Maintenance")]
        UnderMaintenance,
    }
}
