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

        private readonly BookingDBContext _context;

       public BookingDatabaseService(BookingDBContext context)
        {
            _context = context;
        }

        public async Task InsertBookingAsync(Booking booking)
        {
            _context.Booking.Add(booking);
            
            await _context.SaveChangesAsync();
        }

    }
}
