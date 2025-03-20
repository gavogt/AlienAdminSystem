using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class UserDatabaseService
    {
        private readonly UserDBContext _context;

        public UserDatabaseService(UserDBContext context)
        {
            _context = context;
        }

        public async Task InsertUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

        }
    }
}
