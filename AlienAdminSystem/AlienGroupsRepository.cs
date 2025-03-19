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
            new AlienGroup { alienGroupID = 1, alienGroupName = "Zorgons" },
            new AlienGroup { alienGroupID = 2, alienGroupName = "Xenons" },
            new AlienGroup { alienGroupID = 3, alienGroupName = "Galactic Science Consortium" },
            new AlienGroup { alienGroupID = 4, alienGroupName = "Cosmic Cultural Ambassadors" },
            new AlienGroup { alienGroupID = 5, alienGroupName = "Plutonians" },
            new AlienGroup { alienGroupID = 6, alienGroupName = "Martians" },
            new AlienGroup { alienGroupID = 7, alienGroupName = "Intergalactic Arts & Traditions Forum" },
            new AlienGroup { alienGroupID = 8, alienGroupName = "Venusians" },
            new AlienGroup { alienGroupID = 9, alienGroupName = "Interstellar Research Alliance" }

        };

    }
}
