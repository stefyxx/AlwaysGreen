using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Enums
{
    [Flags]
    public enum RolesEnum
    {
        Particular = 1,
        Business = 2,
        Store = 4,
        Depot = 8,
    }
}
