using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal interface IFacilityFilterService
    {
        Task<List<Facility>> GetFilteredFacilitiesAsync(IEnumerable<IFacilityFilterStrategy> strategies);
    }
}
