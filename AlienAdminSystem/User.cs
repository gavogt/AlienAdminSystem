using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AlienAdminSystem
{
    public class User
    {

        [Key]
        public int ID { get; set; }
        public string Username { get; set; } = String.Empty;
        public string HashedPassword { get; set; } = String.Empty;
        public bool IsAdmin { get; set; } = false;
        public Species Species { get; set; }

        public User()
        {
            
        }

        public User(string username, string hashedPassword, Species species)
        {
            Username = username;
            HashedPassword = hashedPassword;
            Species = species;

        }
    }
}
