using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Company: Location
    {
        //numéro de TVA
        public string VATnumber { get; set; }
        public override List<RolesEnum> Roles { get => new List<RolesEnum> { RolesEnum.Company }; }

        #region FK
        public int? SiretId { get; set; }
        [ForeignKey("SiretId")]
        public Siret? Siret { get; set; }
        #endregion
    }
}
