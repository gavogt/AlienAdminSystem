using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal interface IFacilityFilterStrategy
    {

        IQueryable<Facility> Apply(IQueryable<Facility> query);

    }
}
