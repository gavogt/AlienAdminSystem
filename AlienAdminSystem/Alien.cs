using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    [Table("AlienRegisterTable")]
    public abstract class Alien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlienID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Planet is required.")]
        public string Planet { get; set; } = string.Empty;
        [Required(ErrorMessage = "Species is required.")]
        public Species Species { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;
        [Range(0, 1000, ErrorMessage = "Age must be between 0 and 1000.")]
        public int Age { get; set; } = 0;
        [Required(ErrorMessage = "Group ID is required.")]

        [Column("AlienGroupID")]
        public int AlienGroupID { get; set; } = 0;
        [Range(0, 2, ErrorMessage = "Atmosphere type must be between 0 and 2.")]

        [Column("AtmosphereTypeID")]
        public int AtmosphereTypeID { get; set; } = 0;
        public string SpecialRequirements { get; set; } = string.Empty;
        [Range(0, 12, ErrorMessage = "Visit duration must be between 0 and 12 months.")]
        public int VisitDurationMonths { get; set; } = 0;

        public Alien()
        {

        }

        public Alien(string firstName, string lastName, string planet, Species species, string email, int age, int selectedGroupID, int atmosphereType, int visitDurationMonths, string specialRequirements)
        {
            FirstName = firstName;
            LastName = lastName;
            Planet = planet;
            Species = species;
            Email = email;
            Age = age;
            AlienGroupID = selectedGroupID;
            AtmosphereTypeID = atmosphereType;
            VisitDurationMonths = visitDurationMonths;
            SpecialRequirements = specialRequirements;

        }
    }
}
