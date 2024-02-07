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
    //pt raccolta or pt dove spendere il buono (store) , or company (es: Delaize--> store + company)
    //aut Deposito
    //MAI user (Particulier)
    public abstract class Location
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

        //es Delaize puo' essere sia un enterprise che un magasin
        public virtual RolesEnum[] Roles { get; set; }

        #region FK
        public int AddressId { get; set; }
        [ForeignKey("AddressId  ")]
        public Address Address { get; set; }

        public int? TransportId { get; set; }
        [ForeignKey("TransportId")]
        public Transport? Transport { get; set; }

        #endregion

    }
}
