using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Store: Location
    {
        //numéro de TVA
        public string VATnumber { get; set; }
        public override RolesEnum[] Roles { get => [RolesEnum.Store]; }

        #region Store

        //é un pt di raccolta?
        public bool IsPickUpPoint { get; set; } = true;

        //é un pt dove spendere i buoni?
        public bool IsStorePoint { get; set; }

        #endregion

        #region FK
        public int? SiretId { get; set; }
        [ForeignKey("SiretId")]
        public Siret? Siret { get; set; }
        #endregion
    }
}
