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

                string sql = $"INSERT INTO AlienRegisterTable (FirstName, LastName, Planet, Species, Email, Age, AlienGroupID) VALUES ('{registeredAlien.FirstName}', '{registeredAlien.LastName}', '{registeredAlien.Planet}', '{registeredAlien.Species}', '{registeredAlien.Email}', {registeredAlien.Age}, {registeredAlien.SelectedGroupID});";
                using var command = new SqlCommand(sql, connection);

                int rowsAffected = await command.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {
                errorMessage = $"Database insert error: {ex.Message}";

            }
        }

        public async Task<Alien> RegisterTheAlien(string firstName, string lastName, string planet, string species, string email, int age, int selectedGroupID)
        {
            registeredAlien = new Alien(firstName, lastName, planet, species, email, age, selectedGroupID);
            await InsertAlien();
            return registeredAlien;

        }
    }
}
