using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal class EmbassyAtmosphereFilterStrategy : IFacilityFilterStrategy
    {
        private readonly int _requiredAtmosphereTypeID;

        public EmbassyAtmosphereFilterStrategy(int requiredatmosphereTypeID)
        {
            _requiredAtmosphereTypeID = requiredatmosphereTypeID;

        }

        public IQueryable<Facility> Apply(IQueryable<Facility> query)
        {
            // Filter on type Embassy
            // Assigned Facility (embassy) AtmosphereTypeID must match the requiredAtmosphereTypeID
            // Ensure the return type is of type Facility
            return query.OfType<Embassy>()
                .Where(e => e.AtmosphereTypeID == _requiredAtmosphereTypeID)
                .Cast<Facility>();
        }
    }
}
