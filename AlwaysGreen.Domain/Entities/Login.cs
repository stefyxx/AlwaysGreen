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
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }

        //se hai 2 ruoli?
        public RolesEnum[] Roles {  get; set; }

        #region FK

        public int? ParticularId { get; set; }
        [ForeignKey("ParticularId")]
        public Particular? Particular { get; set; }
        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location? Depot { get; set; }

        #endregion

    }
}
