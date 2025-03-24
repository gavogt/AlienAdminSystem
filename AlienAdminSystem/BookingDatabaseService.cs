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

            var facilityExists = await _context.Facilities.AnyAsync(f => f.ID == booking.FacilityID);
            if (!facilityExists)
            {
                throw new InvalidOperationException("Facility does not exist in table.");
            }

            if(booking.Aliens != null)
            foreach(var alien in booking.Aliens)
            {
                bool exists = await _context.Aliens.AnyAsync(a => a.ID == alien.ID);
                if (!exists)
                {
                    throw new InvalidOperationException($"Alien with ID {alien.ID} does not exist in table.");
                }
            }

            try
            {
                _context.Booking.Add(booking);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                await _context.SaveChangesAsync();
            }  catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        
        public async Task<Booking?> GetBookingWithAlienAsync()
        {
            var bookings = await _context.Booking.Include(b => b.Aliens)
                .FirstOrDefaultAsync(b => b.Aliens != null);

            return bookings;

        }
    }
}
