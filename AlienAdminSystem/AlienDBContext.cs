using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class AlienDBContext:DbContext
    {
        public DbSet<Alien> Aliens { get; set; }

        public AlienDBContext(DbContextOptions<AlienDBContext> options) : base(options)
        {
        }
    }
}
