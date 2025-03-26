using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class ResearchLabFilterStrategy : IFacilityFilterStrategy
    {
        private int _labEquipmentCount;

        public ResearchLabFilterStrategy(int labEquipmentCount)
        {
            _labEquipmentCount = labEquipmentCount;
        }
        public IQueryable<Facility> Apply(IQueryable<Facility> query)
        {
            // Filter on type ResearchLab
            // Assigned Facility (ResearchLab) LabEquipmentCount must be greater than or equal to labEquipmentCount
            // Ensure the return type is of type Facility
            return query.OfType<ResearchLab>()
                .Where(e => e.LabEquipmentCount >= _labEquipmentCount)
                .Cast<Facility>();
        }
    }
}
