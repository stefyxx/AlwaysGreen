using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Store : Site
    {
        public override RolesEnum[] Roles => [RolesEnum.Store];

        //é un pt di raccolta?
        public bool IsPickUpPoint { get; set; } = true;

        //é un pt dove spendere i buoni?
        public bool IsStorePoint { get; set;}

    }
}
