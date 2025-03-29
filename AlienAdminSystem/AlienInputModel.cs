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
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Planet is required.")]
        public string Planet { get; set; } = string.Empty;

        [Required(ErrorMessage = "Species is required.")]
        public Species? Species { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 1000, ErrorMessage = "Age must be between 1 and 1000.")]
        public int? Age { get; set; }

        public string SpecialRequirements { get; set; } = string.Empty;

        [Required(ErrorMessage = "Visit duration is required.")]
        [Range(1, 12, ErrorMessage = "Visit duration must be between 1 and 12 months.")]
        public int? VisitDurationMonths { get; set; }

        [Required(ErrorMessage = "Alien group is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Alien group is required.")]
        public int? AlienGroupID { get; set; }

        [Required(ErrorMessage = "Atmosphere type is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Atmosphere type is required.")]
        public int? AtmosphereTypeID { get; set; }
    }
}