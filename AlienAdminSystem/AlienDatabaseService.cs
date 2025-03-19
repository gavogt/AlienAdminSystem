using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class AlienDatabaseService
    {
        private Alien registeredAlien;

        private readonly string _connectionString;

        public string errorMessage = String.Empty;

        public AlienDatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AlienConnection")
                ?? throw new ArgumentNullException("Connection string 'AlienConnection' is missing in appsettings.json.");
        }

        public async Task InsertAlien()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);

                await connection.OpenAsync();

                string sql = "INSERT INTO AlienRegisterTable (FirstName, LastName, Planet, Species, Email, Age, AlienGroupID, AtmosphereTypeID, SpecialRequirements) " +
             "VALUES (@FirstName, @LastName, @Planet, @Species, @Email, @Age, @AlienGroupID, @AtmosphereTypeID, @SpecialRequirements)";

                using var command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@FirstName", registeredAlien.FirstName);
                command.Parameters.AddWithValue("@LastName", registeredAlien.LastName);
                command.Parameters.AddWithValue("@Planet", registeredAlien.Planet);
                command.Parameters.AddWithValue("@Species", registeredAlien.Species);
                command.Parameters.AddWithValue("@Email", registeredAlien.Email);
                command.Parameters.AddWithValue("@Age", registeredAlien.Age);
                command.Parameters.AddWithValue("@AlienGroupID", registeredAlien.SelectedGroupID);
                command.Parameters.AddWithValue("@AtmosphereTypeID", registeredAlien.AtmosphereType);
                command.Parameters.AddWithValue("@SpecialRequirements", registeredAlien.SpecialRequirements);

                int rowsAffected = await command.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {
                errorMessage = $"Database insert error: {ex.Message}";

            }
        }

        public async Task<Alien> RegisterTheAlien(string firstName, string lastName, string planet, string species, string email, int age, int selectedGroupID, int atmosphereType, string specialRequirements)
        {
            registeredAlien = new Alien(firstName, lastName, planet, species, email, age, selectedGroupID, atmosphereType, specialRequirements);
            await InsertAlien();
            return registeredAlien;

        }
    }
}
