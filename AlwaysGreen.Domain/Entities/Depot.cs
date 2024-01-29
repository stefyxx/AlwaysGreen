using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Depot : Site
    {
        public override RolesEnum[] Roles => [RolesEnum.Depot];


    }
}
