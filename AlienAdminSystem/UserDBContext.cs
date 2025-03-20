using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlienAdminSystem
{
    internal class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

    }
}
