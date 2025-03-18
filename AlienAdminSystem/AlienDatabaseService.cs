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

                string sql = $"INSERT INTO AlienRegister (FirstName, LastName, Planet, Species, Email, Age) VALUES ('{registeredAlien.FirstName}', '{registeredAlien.LastName}', '{registeredAlien.Planet}', '{registeredAlien.Species}', '{registeredAlien.Email}', {registeredAlien.Age});";

                using var command = new SqlCommand(sql, connection);

                int rowsAffected = await command.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {
                errorMessage = $"Database insert error: {ex.Message}";

            }
        }

        public async Task<Alien> RegisterTheAlien(string firstName, string lastName, string planet, string species, string email, int age)
        {
            registeredAlien = new Alien(firstName, lastName, planet, species, email, age);
            await InsertAlien();
            return registeredAlien;

        }
    }
}
