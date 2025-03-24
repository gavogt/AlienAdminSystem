﻿// <auto-generated />
using System;
using AlienAdminSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlienAdminSystem.Migrations
{
    [DbContext(typeof(AlienDBContext))]
    partial class AlienDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlienAdminSystem.Alien", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("AlienGroupID")
                        .HasColumnType("int")
                        .HasColumnName("AlienGroupID");

                    b.Property<string>("AlienType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("AtmosphereTypeID")
                        .HasColumnType("int")
                        .HasColumnName("AtmosphereTypeID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Planet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialRequirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Species")
                        .HasColumnType("int");

                    b.Property<int>("VisitDurationMonths")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AlienRegisterTable");

                    b.HasDiscriminator<string>("AlienType").HasValue("Alien");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AlienAdminSystem.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AlienID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacilityID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfVisitors")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AlienID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("AlienAdminSystem.Facility", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AtmosphereTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacilityTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialRequirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Facilities");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("AlienAdminSystem.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("Species")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AlienAdminSystem.Grey", b =>
                {
                    b.HasBaseType("AlienAdminSystem.Alien");

                    b.ToTable("AlienRegisterTable");

                    b.HasDiscriminator().HasValue("Grey");
                });

            modelBuilder.Entity("AlienAdminSystem.Hybrid", b =>
                {
                    b.HasBaseType("AlienAdminSystem.Alien");

                    b.ToTable("AlienRegisterTable");

                    b.HasDiscriminator().HasValue("Hybrid");
                });

            modelBuilder.Entity("AlienAdminSystem.Reptilian", b =>
                {
                    b.HasBaseType("AlienAdminSystem.Alien");

                    b.ToTable("AlienRegisterTable");

                    b.HasDiscriminator().HasValue("Reptilian:");
                });

            modelBuilder.Entity("AlienAdminSystem.TimeTraveler", b =>
                {
                    b.HasBaseType("AlienAdminSystem.Alien");

                    b.ToTable("AlienRegisterTable");

                    b.HasDiscriminator().HasValue("TimeTraveler");
                });

            modelBuilder.Entity("AlienAdminSystem.Embassy", b =>
                {
                    b.HasBaseType("AlienAdminSystem.Facility");

                    b.Property<int>("RequiredAtmosphereTypeID")
                        .HasColumnType("int");

                    b.ToTable("Embassies", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 3,
                            AtmosphereTypeID = 3,
                            Capacity = 250,
                            Description = "Welcome to the Interplanetary Peace Center, a diplomatic haven where alien delegates and Earth’s representatives collaborate on universal policies.",
                            FacilityTypeID = 1,
                            Name = "Interplanetary Peace Center",
                            Status = "Open",
                            RequiredAtmosphereTypeID = 1
                        },
                        new
                        {
                            ID = 4,
                            AtmosphereTypeID = 2,
                            Capacity = 180,
                            Description = "The Stellar Harmony Embassy stands as a beacon of intergalactic cooperation. Its grand halls and luminous architecture create a welcoming atmosphere for extraterrestrial envoys.",
                            FacilityTypeID = 1,
                            Name = "Stellar Harmony Embassy",
                            Status = "Open",
                            RequiredAtmosphereTypeID = 2
                        },
                        new
                        {
                            ID = 5,
                            AtmosphereTypeID = 3,
                            Capacity = 160,
                            Description = "The Cosmic Unity Consulate fosters unity and cooperation across intergalactic borders. It features modern communication hubs and advanced security systems.",
                            FacilityTypeID = 1,
                            Name = "Cosmic Unity Consulate",
                            Status = "Open",
                            RequiredAtmosphereTypeID = 1
                        });
                });

            modelBuilder.Entity("AlienAdminSystem.QuarantineZone", b =>
                {
                    b.HasBaseType("AlienAdminSystem.Facility");

                    b.Property<bool>("IsAccessible")
                        .HasColumnType("bit");

                    b.ToTable("QuarantineZones", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AtmosphereTypeID = 1,
                            Capacity = 200,
                            Description = "Designed to safely contain and treat extraterrestrial visitors, the Galactic Infirmary Quarantine Zone is equipped with advanced sterilization chambers, specialized atmospheric controls, and robust security protocols.",
                            FacilityTypeID = 3,
                            Name = "Galactic Infirmary Quarantine Zone",
                            Status = "Open",
                            IsAccessible = true
                        },
                        new
                        {
                            ID = 2,
                            AtmosphereTypeID = 2,
                            Capacity = 150,
                            Description = "The Celestial Containment Facility offers cutting-edge solutions for alien quarantine and observation. Utilizing energy barriers, bio-shield walls, and a fully automated check-in system, it ensures minimal contact while maximizing scientific collaboration.",
                            FacilityTypeID = 3,
                            Name = "Celestial Containment Facility",
                            Status = "UnderMaintenance",
                            IsAccessible = false
                        });
                });

            modelBuilder.Entity("AlienAdminSystem.ResearchLab", b =>
                {
                    b.HasBaseType("AlienAdminSystem.Facility");

                    b.Property<int>("LabEquipmentCount")
                        .HasColumnType("int");

                    b.ToTable("ResearchLabs", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 6,
                            AtmosphereTypeID = 1,
                            Capacity = 300,
                            Description = "Welcome to the Advanced Xenobiology Research Lab, where cutting-edge discoveries shape interspecies cooperation. Dedicated to studying and enhancing biological adaptation.",
                            FacilityTypeID = 2,
                            Name = "Galactic Sciences Division – Earth Sector",
                            Status = "UnderMaintenance",
                            LabEquipmentCount = 200
                        },
                        new
                        {
                            ID = 7,
                            AtmosphereTypeID = 1,
                            Capacity = 220,
                            Description = "Unlock the potential of quantum mechanics and sustainable cosmic energy at the Quantum Tech & Energy Research Facility!",
                            FacilityTypeID = 2,
                            Name = "Quantum Tech & Energy Research Facility",
                            Status = "Open",
                            LabEquipmentCount = 63
                        },
                        new
                        {
                            ID = 8,
                            AtmosphereTypeID = 1,
                            Capacity = 280,
                            Description = "At the Cosmic Terraforming & Environmental Adaptation Center, pioneering techniques are applied to re-engineer planetary environments for alien habitation.",
                            FacilityTypeID = 2,
                            Name = "Cosmic Terraforming & Environmental Adaptation Center",
                            Status = "Open",
                            LabEquipmentCount = 16
                        });
                });

            modelBuilder.Entity("AlienAdminSystem.Booking", b =>
                {
                    b.HasOne("AlienAdminSystem.Alien", "Alien")
                        .WithMany()
                        .HasForeignKey("AlienID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alien");
                });

            modelBuilder.Entity("AlienAdminSystem.Embassy", b =>
                {
                    b.HasOne("AlienAdminSystem.Facility", null)
                        .WithOne()
                        .HasForeignKey("AlienAdminSystem.Embassy", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlienAdminSystem.QuarantineZone", b =>
                {
                    b.HasOne("AlienAdminSystem.Facility", null)
                        .WithOne()
                        .HasForeignKey("AlienAdminSystem.QuarantineZone", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlienAdminSystem.ResearchLab", b =>
                {
                    b.HasOne("AlienAdminSystem.Facility", null)
                        .WithOne()
                        .HasForeignKey("AlienAdminSystem.ResearchLab", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
