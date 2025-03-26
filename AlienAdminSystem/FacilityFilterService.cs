using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class FacilityFilterService : IFacilityFilterService
    {
        private readonly AlienDBContext _context;

        public FacilityFilterService(AlienDBContext context)
        {
            _context = context;
        }

        public async Task<List<Facility>> GetFilteredFacilitiesAsync(IEnumerable<IFacilityFilterStrategy> strategies)
        {
            // Include AtmosphereType in Facility Class currently listed as a navigation property
            IQueryable<Facility> query = _context.Facilities
                .Include(f => f.AtmosphereType)
                .Include(f => f.FacilityType);

            // Apply each strategy to the query
            foreach (var strategy in strategies)
            {
                query = strategy.Apply(query);
            }

            // Execute the query and return the results as a list
            return await query.ToListAsync();
        }
    }
}
