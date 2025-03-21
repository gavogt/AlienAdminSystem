using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class BookingDBContext:DbContext
    {
           
        public DbSet<Booking> Booking { get; set; }

        public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options) { }

    }
}
