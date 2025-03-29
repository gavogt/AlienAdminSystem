using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlienAdminSystem
{
    internal class BookingApprovalService
    {
        private AlienDBContext _context;

        public BookingApprovalService(AlienDBContext context)
        {
            _context = context;
        }

        public async Task InsertBookingApprovalAsync(BookingApproval bookingApproval)
        {
            try
            {
                _context.BookingApproval.Add(bookingApproval);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<List<BookingApproval>> GetBookingApprovalAsync()
        {
            return await _context.BookingApproval.ToListAsync();

        }

        public async Task UpdateBookingApprovalAsync(BookingApproval bookingApproval)
        {
            try
            {
                _context.BookingApproval.Update(bookingApproval);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}