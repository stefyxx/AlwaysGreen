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
    public class Login
    {
        [Key]
        public int? Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public RolesEnum Role {  get; set; }

        #region FK
        public int? ParticularId { get; set; }
        [ForeignKey("ParticularId")]
        public Particular? Particular { get; set; }
        public int? DepoId { get; set; }
        [ForeignKey("DepoId")]
        public Depot? Depot { get; set; }
        public int? BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business? Business { get; set; }
        public int? StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store? Store { get; set; }
        #endregion

    }
}
