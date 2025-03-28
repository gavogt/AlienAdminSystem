using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
