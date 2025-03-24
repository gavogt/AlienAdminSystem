using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Design;

namespace AlienAdminSystem
{
    internal class AlienDBContext : DbContext
    {
        public DbSet<Alien> Aliens { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Embassy> Embassy { get; set; }
        public DbSet<ResearchLab> ResearchLab { get; set; }
        public DbSet<QuarantineZone> QuarantineZone { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        public AlienDBContext(DbContextOptions<AlienDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship booking to Alien
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Alien)
                .WithMany()
                .HasForeignKey(b => b.AlienID);

            modelBuilder.Entity<Booking>()
                .Property(b => b.ID)
                .ValueGeneratedOnAdd();

            // Configure TPT inheritance
            modelBuilder.Entity<Facility>().UseTptMappingStrategy();
            modelBuilder.Entity<Embassy>().ToTable("Embassies");
            modelBuilder.Entity<ResearchLab>().ToTable("ResearchLabs");
            modelBuilder.Entity<QuarantineZone>().ToTable("QuarantineZones");

            // Configure TPH inheritance for Alien
            modelBuilder.Entity<Alien>()
                .HasDiscriminator<string>("AlienType")
                .HasValue<TimeTraveler>("TimeTraveler")
                .HasValue<Reptilian>("Reptilian:")
                .HasValue<Grey>("Grey")
                .HasValue<Hybrid>("Hybrid");

            // Convert Species enum to int for database storage
            modelBuilder.Entity<Alien>()
                .Property(a => a.Species)
                .HasConversion<int>();

            // Convert Status to string for database storage
            modelBuilder.Entity<Facility>()
                .Property(f => f.Status)
                .HasConversion<string>();

            // QuarantineZone (IDs 1 & 2)
            modelBuilder.Entity<QuarantineZone>().HasData(
                new
                {
                    ID = 1,
                    // Base Facility fields:
                    Name = "Galactic Infirmary Quarantine Zone",
                    Capacity = 200,
                    Status = Status.Open,
                    FacilityTypeID = 3, // Quarantine Zone
                    AtmosphereTypeID = 1, // Oxygen
                    Description = "Designed to safely contain and treat extraterrestrial visitors, " +
                                 "the Galactic Infirmary Quarantine Zone is equipped with advanced sterilization chambers, " +
                                 "specialized atmospheric controls, and robust security protocols.",
                    // Derived field:
                    IsAccessible = true
                },
                new
                {
                    ID = 2,
                    Name = "Celestial Containment Facility",
                    Capacity = 150,
                    Status = Status.UnderMaintenance,
                    FacilityTypeID = 3, // Quarantine Zone
                    AtmosphereTypeID = 2,
                    Description = "The Celestial Containment Facility offers cutting-edge solutions for alien quarantine " +
                                 "and observation. Utilizing energy barriers, bio-shield walls, and a fully automated " +
                                 "check-in system, it ensures minimal contact while maximizing scientific collaboration.",
                    IsAccessible = false
                }
            );

            // Embassy (IDs 3, 4, 5)
            modelBuilder.Entity<Embassy>().HasData(
                new
                {
                    ID = 3,
                    // Base Facility fields:
                    Name = "Interplanetary Peace Center",
                    Capacity = 250,
                    Status = Status.Open,
                    FacilityTypeID = 1, // Embassy
                    AtmosphereTypeID = 3,
                    Description = "Welcome to the Interplanetary Peace Center, a diplomatic haven where alien delegates " +
                                 "and Earth’s representatives collaborate on universal policies.",
                    // Derived field:
                    RequiredAtmosphereTypeID = 1
                },
                new
                {
                    ID = 4,
                    Name = "Stellar Harmony Embassy",
                    Capacity = 180,
                    Status = Status.Open,
                    FacilityTypeID = 1, // Embassy
                    AtmosphereTypeID = 2,
                    Description = "The Stellar Harmony Embassy stands as a beacon of intergalactic cooperation. " +
                                 "Its grand halls and luminous architecture create a welcoming atmosphere for extraterrestrial envoys.",
                    RequiredAtmosphereTypeID = 2
                },
                new
                {
                    ID = 5,
                    Name = "Cosmic Unity Consulate",
                    Capacity = 160,
                    Status = Status.Open,
                    FacilityTypeID = 1, // Embassy
                    AtmosphereTypeID = 3,
                    Description = "The Cosmic Unity Consulate fosters unity and cooperation across intergalactic borders. " +
                                 "It features modern communication hubs and advanced security systems.",
                    RequiredAtmosphereTypeID = 1
                }
            );

            // ResearchLab (IDs 6, 7, 8)
            modelBuilder.Entity<ResearchLab>().HasData(
                new
                {
                    ID = 6,
                    // Base Facility fields:
                    Name = "Galactic Sciences Division – Earth Sector",
                    Capacity = 300,
                    Status = Status.UnderMaintenance,
                    FacilityTypeID = 2, // Research Lab
                    AtmosphereTypeID = 1,
                    Description = "Welcome to the Advanced Xenobiology Research Lab, where cutting-edge discoveries " +
                                 "shape interspecies cooperation. Dedicated to studying and enhancing biological adaptation.",
                    // Derived field:
                    LabEquipmentCount = 200
                },
                new
                {
                    ID = 7,
                    Name = "Quantum Tech & Energy Research Facility",
                    Capacity = 220,
                    Status = Status.Open,
                    FacilityTypeID = 2, // Research Lab
                    AtmosphereTypeID = 1,
                    Description = "Unlock the potential of quantum mechanics and sustainable cosmic energy " +
                                 "at the Quantum Tech & Energy Research Facility!",
                    LabEquipmentCount = 63
                },
                new
                {
                    ID = 8,
                    Name = "Cosmic Terraforming & Environmental Adaptation Center",
                    Capacity = 280,
                    Status = Status.Open,
                    FacilityTypeID = 2, // Research Lab
                    AtmosphereTypeID = 1,
                    Description = "At the Cosmic Terraforming & Environmental Adaptation Center, pioneering techniques " +
                                 "are applied to re-engineer planetary environments for alien habitation.",
                    LabEquipmentCount = 16
                }
            );

            base.OnModelCreating(modelBuilder);

        }
    }
}
