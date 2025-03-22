using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class BookingDatabaseService
    {

        private readonly AlienDBContext _context;

        public BookingDatabaseService(AlienDBContext context)
        {
            _context = context;
        }

        public async Task InsertBookingAsync(Booking booking)
        {
            _context.Booking.Add(booking);

            await _context.SaveChangesAsync();
        }

        public async Task<Booking?> GetBookingWithAlienAsync()
        {
            var bookings = await _context.Booking.Include(b => b.Alien)
                .FirstOrDefaultAsync(b => b.Alien != null);

            return bookings;

        }
    }
}
