using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAdminSystem
{
    internal static class AlienGroupsRepository
    {
        public static List<AlienGroup> ListAllGroups() => new List<AlienGroup>()
        {
            new AlienGroup { ID = 1, Name = "Zorgons" },
            new AlienGroup { ID = 2, Name = "Xenons" },
            new AlienGroup { ID = 3, Name = "Galactic Science Consortium" },
            new AlienGroup { ID = 4, Name = "Cosmic Cultural Ambassadors" },
            new AlienGroup { ID = 5, Name = "Plutonians" },
            new AlienGroup { ID = 6, Name = "Martians" },
            new AlienGroup { ID = 7, Name = "Intergalactic Arts & Traditions Forum" },
            new AlienGroup { ID = 8, Name = "Venusians" },
            new AlienGroup { ID = 9, Name = "Interstellar Research Alliance" }

        };

    }
}
