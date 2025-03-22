using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlienAdminSystem
{
    internal class FacilityDBContext : DbContext
    {
        public DbSet<Facility> Facilities { get; set; }

        public FacilityDBContext(DbContextOptions<FacilityDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create column in Facility for Environmental Controls
            modelBuilder.Entity<Facility>(entity =>
            {
                entity.OwnsOne(f => f.EnvironmentalControls, ec =>
                {
                    ec.Property(e => e.HasRadiationShielding).HasColumnName("EnvironmentalControls_HasRadiationShielding");
                    ec.Property(e => e.HasAntiGravitySystems).HasColumnName("EnvironmentalControls_HasAntiGravitySystems");

                });

                base.OnModelCreating(modelBuilder);

            });

            // Seed the database with Facilities
            modelBuilder.Entity<Facility>().HasData(
                new Facility
                {
                    ID = 1,
                    Name = "Galactic Infirmary Quarantine Zone",
                    Capacity = 200,
                    Status = "Available",
                    FacilityTypeID = 3,       // Quarantine Zone
                    AtmosphereTypeID = 1,       // Example Oxygen
                    Description = "Designed to safely contain and treat extraterrestrial visitors, the Galactic Infirmary Quarantine Zone is equipped with advanced sterilization chambers, specialized atmospheric controls, and robust security protocols. Key Features: Multi-species medical labs, reinforced isolation wards, and automated drone monitoring for continuous safety checks."
                },
                new Facility
                {
                    ID = 2,
                    Name = "Celestial Containment Facility",
                    Capacity = 150,
                    Status = "Available",
                    FacilityTypeID = 3,       // Quarantine Zone
                    AtmosphereTypeID = 1,
                    Description = "The Celestial Containment Facility offers cutting-edge solutions for alien quarantine and observation. Utilizing energy barriers, bio-shield walls, and a fully automated check-in system, it ensures minimal contact while maximizing scientific collaboration and safety. Essential Elements: Adaptable bio-secure enclosures, intelligent alert systems, and holographic diagnostic interfaces."
                },
                new Facility
                {
                    ID = 3,
                    Name = "Interplanetary Peace Center",
                    Capacity = 250,
                    Status = "Available",
                    FacilityTypeID = 1,       // Embassy type
                    AtmosphereTypeID = 1,
                    Description = "Welcome to the Interplanetary Peace Center, a diplomatic haven where alien delegates and Earth’s representatives collaborate on universal policies. Equipped with advanced translation devices and serene meeting chambers, it fosters cultural exchange and alliance building."
                },
                new Facility
                {
                    ID = 4,
                    Name = "Stellar Harmony Embassy",
                    Capacity = 180,
                    Status = "Available",
                    FacilityTypeID = 1,       // Embassy
                    AtmosphereTypeID = 2,    
                    Description = "The Stellar Harmony Embassy stands as a beacon of intergalactic cooperation. Its grand halls and luminous architecture create a welcoming atmosphere for extraterrestrial envoys, with advanced diplomatic technologies and secure data vaults ensuring confidentiality."
                },
                new Facility
                {
                    ID = 5,
                    Name = "Cosmic Unity Consulate",
                    Capacity = 160,
                    Status = "Available",
                    FacilityTypeID = 1,       // Embassy
                    AtmosphereTypeID = 3,    
                    Description = "The Cosmic Unity Consulate fosters unity and cooperation across intergalactic borders. It features modern communication hubs, state-of-the-art security systems, and streamlined processes to resolve interstellar disputes while promoting cultural exchange."
                },
                new Facility
                {
                    ID = 6,
                    Name = "Galactic Sciences Division – Earth Sector",
                    Capacity = 300,
                    Status = "Available",
                    FacilityTypeID = 2,       // Research Lab
                    AtmosphereTypeID = 1,
                    Description = "Welcome to the Advanced Xenobiology Research Lab, where cutting-edge discoveries shape interspecies cooperation. Dedicated to studying and enhancing biological adaptation, this facility offers zero-gravity biospheres, holographic genome mapping, and secure intergalactic specimen storage."
                },
                new Facility
                {
                    ID = 7,
                    Name = "Quantum Tech & Energy Research Facility",
                    Capacity = 220,
                    Status = "Available",
                    FacilityTypeID = 2,       // Research Lab
                    AtmosphereTypeID = 1,
                    Description = "Unlock the potential of quantum mechanics and sustainable cosmic energy at the Quantum Tech & Energy Research Facility! Specializing in dark matter energy, zero-point propulsion, and multidimensional computational models, it is a hub for groundbreaking experiments and technological innovation."
                },
                new Facility
                {
                    ID = 8,
                    Name = "Cosmic Terraforming & Environmental Adaptation Center",
                    Capacity = 280,
                    Status = "Available",
                    FacilityTypeID = 2,       // Research Lab
                    AtmosphereTypeID = 1,
                    Description = "At the Cosmic Terraforming & Environmental Adaptation Center, pioneering techniques are applied to re-engineer planetary environments. Focused on sustainable biosphere regeneration and advanced atmospheric modifications, this facility is key to adapting Earth-like conditions for alien habitation."
                }

                );
        }
    }
}