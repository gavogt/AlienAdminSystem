using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class DbSeeder
    {
        public static void SeedAdmin(AlienDBContext context, IConfiguration config)
        {
            // Retrieve admin credentials from configuration
            var adminSection = config.GetSection("AdminCredentials");
            var adminUsername = adminSection["Username"];
            var adminPassword = adminSection["Password"];

            if(string.IsNullOrWhiteSpace(adminUsername) || string.IsNullOrWhiteSpace(adminPassword))
            {
                throw new Exception("Admin credentials are not set in the configuration.");
            }

            // Check DB where IsAdmin is true
            bool adminExists = context.Users.Any(u => u.IsAdmin);

            // If no admin user exists, create one
            if (!adminExists)
            {
                var hashedPassword = PasswordHelper.HashPassword(adminPassword);

                var adminUser = new User
                {
                    Username = adminUsername,
                    HashedPassword = hashedPassword,
                    IsAdmin = true
                };

                context.Users.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}
