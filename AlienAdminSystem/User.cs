using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class User
    {

        public int ID { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
