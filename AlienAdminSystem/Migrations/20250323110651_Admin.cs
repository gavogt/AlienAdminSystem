using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlienAdminSystem.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlienRegisterTable",
                columns: table => new
                {
                    AlienID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Planet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AlienGroupID = table.Column<int>(type: "int", nullable: false),
                    AtmosphereTypeID = table.Column<int>(type: "int", nullable: false),
                    SpecialRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitDurationMonths = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlienRegisterTable", x => x.AlienID);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    SpecialRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityTypeID = table.Column<int>(type: "int", nullable: false),
                    AtmosphereTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityID = table.Column<int>(type: "int", nullable: false),
                    AlienID = table.Column<int>(type: "int", nullable: false),
                    NumberOfVisitors = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_AlienRegisterTable_AlienID",
                        column: x => x.AlienID,
                        principalTable: "AlienRegisterTable",
                        principalColumn: "AlienID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Embassies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    RequiredAtmosphereTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embassies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Embassies_Facilities_ID",
                        column: x => x.ID,
                        principalTable: "Facilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuarantineZones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    IsAccessible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarantineZones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuarantineZones_Facilities_ID",
                        column: x => x.ID,
                        principalTable: "Facilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchLabs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    LabEquipmentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchLabs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResearchLabs_Facilities_ID",
                        column: x => x.ID,
                        principalTable: "Facilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "ID", "AtmosphereTypeID", "Capacity", "Description", "FacilityTypeID", "Name", "SpecialRequirements", "Status" },
                values: new object[,]
                {
                    { 1, 1, 200, "Designed to safely contain and treat extraterrestrial visitors, the Galactic Infirmary Quarantine Zone is equipped with advanced sterilization chambers, specialized atmospheric controls, and robust security protocols.", 3, "Galactic Infirmary Quarantine Zone", null, "Available" },
                    { 2, 2, 150, "The Celestial Containment Facility offers cutting-edge solutions for alien quarantine and observation. Utilizing energy barriers, bio-shield walls, and a fully automated check-in system, it ensures minimal contact while maximizing scientific collaboration.", 3, "Celestial Containment Facility", null, "Available" },
                    { 3, 3, 250, "Welcome to the Interplanetary Peace Center, a diplomatic haven where alien delegates and Earth’s representatives collaborate on universal policies.", 1, "Interplanetary Peace Center", null, "Available" },
                    { 4, 2, 180, "The Stellar Harmony Embassy stands as a beacon of intergalactic cooperation. Its grand halls and luminous architecture create a welcoming atmosphere for extraterrestrial envoys.", 1, "Stellar Harmony Embassy", null, "Available" },
                    { 5, 3, 160, "The Cosmic Unity Consulate fosters unity and cooperation across intergalactic borders. It features modern communication hubs and advanced security systems.", 1, "Cosmic Unity Consulate", null, "Available" },
                    { 6, 1, 300, "Welcome to the Advanced Xenobiology Research Lab, where cutting-edge discoveries shape interspecies cooperation. Dedicated to studying and enhancing biological adaptation.", 2, "Galactic Sciences Division – Earth Sector", null, "Available" },
                    { 7, 1, 220, "Unlock the potential of quantum mechanics and sustainable cosmic energy at the Quantum Tech & Energy Research Facility!", 2, "Quantum Tech & Energy Research Facility", null, "Available" },
                    { 8, 1, 280, "At the Cosmic Terraforming & Environmental Adaptation Center, pioneering techniques are applied to re-engineer planetary environments for alien habitation.", 2, "Cosmic Terraforming & Environmental Adaptation Center", null, "Available" }
                });

            migrationBuilder.InsertData(
                table: "Embassies",
                columns: new[] { "ID", "RequiredAtmosphereTypeID" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "QuarantineZones",
                columns: new[] { "ID", "IsAccessible" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, false }
                });

            migrationBuilder.InsertData(
                table: "ResearchLabs",
                columns: new[] { "ID", "LabEquipmentCount" },
                values: new object[,]
                {
                    { 6, 200 },
                    { 7, 63 },
                    { 8, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AlienID",
                table: "Booking",
                column: "AlienID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Embassies");

            migrationBuilder.DropTable(
                name: "QuarantineZones");

            migrationBuilder.DropTable(
                name: "ResearchLabs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AlienRegisterTable");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}
