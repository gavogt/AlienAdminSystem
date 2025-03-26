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

        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<AtmosphereType> AtmosphereTypes { get; set; }
        public DbSet<AlienGroup> AlienGroups { get; set; }

        public AlienDBContext(DbContextOptions<AlienDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Create Join Table with AlienID and BookingID foreign keys
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Aliens)
                .WithMany(a => a.Bookings)
                .UsingEntity<Dictionary<string, object>>(
                    "AlienBooking",
                    j => j
                        .HasOne<Alien>()
                        .WithMany()
                        .HasForeignKey("AlienID"),
                    j => j
                        .HasOne<Booking>()
                        .WithMany()
                        .HasForeignKey("BookingID")
                );

            // Generate new ID value on Add
            modelBuilder.Entity<Booking>()
            .Property(b => b.ID)
            .ValueGeneratedOnAdd();

            // Join Booking User on UserID
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserID);

            // Configure TPT inheritance
            modelBuilder.Entity<Facility>().UseTptMappingStrategy();
            modelBuilder.Entity<Embassy>().ToTable("Embassies");
            modelBuilder.Entity<ResearchLab>().ToTable("ResearchLabs");
            modelBuilder.Entity<QuarantineZone>().ToTable("QuarantineZones");

            // Configure TPH inheritance for Alien
            modelBuilder.Entity<Alien>()
                .HasDiscriminator<Species>("Species")
                .HasValue<TimeTraveler>(Species.TimeTraveler)
                .HasValue<Reptilian>(Species.Reptilian)
                .HasValue<Grey>(Species.Grey)
                .HasValue<Hybrid>(Species.Hybrid);

            // Convert Species enum to int for database storage
            modelBuilder.Entity<Alien>()
                .Property(a => a.Species)
                .HasConversion<int>();

            // Convert Status to string for database storage
            modelBuilder.Entity<Facility>()
                .Property(f => f.Status)
                .HasConversion<string>();

            // Build the AtmosphereType Table with EF and seed the Database
            modelBuilder.Entity<AtmosphereType>().HasData(
                new AtmosphereType { ID = 1, Name = "Oxygen" },
                new AtmosphereType { ID = 2, Name = "Nitrogen" },
                new AtmosphereType { ID = 3, Name = "Hydrogen" },
                new AtmosphereType { ID = 4, Name = "Carbon Dioxide" },
                new AtmosphereType { ID = 5, Name = "Methane" });

            // Build the FacilityType Table with EF and seed the Database
            modelBuilder.Entity<FacilityType>().HasData(
                new FacilityType { ID = 1, Name = "Embassy" },
                new FacilityType { ID = 2, Name = "Research Lab" },
                new FacilityType { ID = 3, Name = "Quarantine Zone" });

            // Build the AlienGroup Table with EF and seed the Database
            modelBuilder.Entity<AlienGroup>().HasData(
             new AlienGroup { ID = 1, Name = "Zorgons" },
             new AlienGroup { ID = 2, Name = "Xenons" },
             new AlienGroup { ID = 3, Name = "Galactic Science Consortium" },
             new AlienGroup { ID = 4, Name = "Cosmic Cultural Ambassadors" },
             new AlienGroup { ID = 5, Name = "Plutonians" },
             new AlienGroup { ID = 6, Name = "Martians" },
             new AlienGroup { ID = 7, Name = "Intergalactic Arts & Traditions Forum" },
             new AlienGroup { ID = 8, Name = "Venusians" },
             new AlienGroup { ID = 9, Name = "Interstellar Research Alliance" });

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
                    IsAccessible = false
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
                    AtmosphereTypeID = 1,
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

            // Configure Owned Entity Properties with EnvironmentalControls for Facility
            modelBuilder.Entity<Facility>()
                .OwnsOne(f => f.EnvironmentalControls, ec =>
                {
                    ec.Property(e => e.HasRadiationShielding)
                      .HasColumnName("HasRadiationShielding");
                    ec.Property(e => e.HasAntiGravitySystems)
                      .HasColumnName("HasAntiGravitySystems");

                    ec.HasData(
                        new
                        {
                            FacilityID = 1,
                            HasRadiationShielding = true,
                            HasAntiGravitySystems = false
                        },
                        new
                        {
                            FacilityID = 2,
                            HasRadiationShielding = false,
                            HasAntiGravitySystems = true
                        },
                        new
                        {
                            FacilityID = 3,
                            HasRadiationShielding = true,
                            HasAntiGravitySystems = false
                        },
                        new
                        {
                            FacilityID = 4,
                            HasRadiationShielding = false,
                            HasAntiGravitySystems = true
                        },
                        new
                        {
                            FacilityID = 5,
                            HasRadiationShielding = true,
                            HasAntiGravitySystems = false
                        },
                        new
                        {
                            FacilityID = 6,
                            HasRadiationShielding = false,
                            HasAntiGravitySystems = true
                        },
                        new
                        {
                            FacilityID = 7,
                            HasRadiationShielding = true,
                            HasAntiGravitySystems = false
                        },
                        new
                        {
                            FacilityID = 8,
                            HasRadiationShielding = false,
                            HasAntiGravitySystems = true
                        }
                    );
                });


            base.OnModelCreating(modelBuilder);

        }
    }
}
