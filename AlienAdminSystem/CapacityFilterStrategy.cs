using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class CapacityFilterStrategy : IFacilityFilterStrategy
    {
        private readonly int _minCapacity;

        public CapacityFilterStrategy(int minCapacity)
        {
            _minCapacity = minCapacity;
        }

        public IQueryable<Facility> Apply(IQueryable<Facility> query)
        {
            // Filter on Facility.Capacity >= minCapacity
            return query.Where(f => f.Capacity >= _minCapacity);
        }
    }
}
