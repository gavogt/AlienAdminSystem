using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlienAdminSystem
{
    internal class FacilityDatabaseService
    {
        private readonly AlienDBContext _dbContext;

        public FacilityDatabaseService(AlienDBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Facility>> GetFacilitiesASync()
        {
            return await _dbContext.Facilities.ToListAsync();
        }

        public async Task UpdateFacilityStatusAsync(int ID, Status newStatus)
        {
            var facility = await _dbContext.Facilities.FindAsync(ID);
            if (facility != null)
            {
                facility.Status = newStatus;
                _dbContext.Facilities.Update(facility);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
