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
    public class Particular 
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Email { get; set; }

        public RolesEnum[] Roles
        {
            get => [RolesEnum.Particular];
        }

        public bool IsActive { get; set; } = true;

        #region FK
        public int AddressId {  get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        //che in realtà ne avrà uno solo
        public List<Login> Logins { get; set; } = [];

        #endregion
    }
}
