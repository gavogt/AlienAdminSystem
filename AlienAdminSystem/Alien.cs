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
        public int ID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } 
        [Required(ErrorMessage = "Planet is required.")]
        public string Planet { get; set; } 
        [Required(ErrorMessage = "Species is required.")]
        public Species Species { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } 
        [Range(1, 1000, ErrorMessage = "Age must be between 1 and 1000.")]
        [Required(ErrorMessage = "Age is required.")]
        public int? Age { get; set; }

        public string SpecialRequirements { get; set; } 
        [Range(1, 12, ErrorMessage = "Visit duration must be between 1 and 12 months.")]
        [Required(ErrorMessage = "Visit duration is required.")]
        public int? VisitDurationMonths { get; set; } 

        // Foreign Key
        [Required(ErrorMessage = "Alien group is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Alien group is required")]
        [Column("AlienGroupID")]
        public int? AlienGroupID { get; set; }


        // Foreign Key
        [Required(ErrorMessage = "Atmosphere type is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Atmosphere type is required.")]
        [Column("AtmosphereTypeID")]
        public int? AtmosphereTypeID { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public AlienGroup? AlienGroup { get; set; }
        public AtmosphereType? AtmosphereType { get; set; }

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
