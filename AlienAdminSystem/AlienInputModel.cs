using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlienAdminSystem
{
    internal class AlienInputModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Planet is required.")]
        public string Planet { get; set; } = String.Empty;
        [Required(ErrorMessage = "Species is required.")]
        public Species Species { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = String.Empty;
        [Range(0, 1000, ErrorMessage = "Age must be between 0 and 1000.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Group ID is required.")]
        public int AlienGroupID { get; set; }
        [Range(0, 2, ErrorMessage = "Atmosphere type must be between 0 and 2.")]
        public int AtmosphereTypeID { get; set; } = 0;
        public string SpecialRequirements { get; set; } = String.Empty;
        [Range(0, 12, ErrorMessage = "Visit duration must be between 0 and 12 months.")]
        public int VisitDurationMonths { get; set; }
    }
}
