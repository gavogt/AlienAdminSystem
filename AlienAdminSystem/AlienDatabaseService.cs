using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class AlienDatabaseService
    {

        private readonly AlienDBContext _context;

        public AlienDatabaseService(AlienDBContext context)
        {
            _context = context;
        }

        public async Task<Alien> InsertAlienAsync(Alien alien)
        {
            _context.Aliens.Add(alien);
            await _context.SaveChangesAsync();
            return alien;

        }
    }
}
