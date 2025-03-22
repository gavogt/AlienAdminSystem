using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class BookingDBContext : DbContext
    {

        public DbSet<Booking> Booking { get; set; }

        public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Alien) // Each booking has one alien
                .WithMany() // An alien can have many bookings
                .HasForeignKey(b => b.AlienID); // Foreign key in Booking table is alienID

            base.OnModelCreating(modelBuilder);

        }
    }
}
