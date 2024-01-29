using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public abstract class Site
    {
        [Key]
        public int Id { get; set; }
        //Nome particolare--> nome dell'agenzia
        public string? Name { get; set; }

        //for depot --> null
        public string? CompanyName { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        //NNBB: email non unica perché uno store puo' essere anche un business
        [Column(TypeName = "varchar(75)")]
        public string Email { get; set; }

        //numéro de TVA
        public string VATnumber { get; set; }


        //es Delaize puo' essere sia un enterprise che un magasin
        public abstract RolesEnum[] Roles { get; }

        #region FK
        public int? AddressId { get; set; }
        [ForeignKey("AddressId  ")]
        public Address? Address { get; set; }

        public int? SiretId { get; set; }
        [ForeignKey("SiretId")]
        public Siret? Siret { get; set; }
        
        #endregion

    }
}
