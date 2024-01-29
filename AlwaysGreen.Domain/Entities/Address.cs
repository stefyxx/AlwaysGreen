using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Address
    {
        [Key]
        public int? Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string? Apartment { get; set; }
        public string? Unit { get; set; }
        public string? UnitNumber { get; set; }
        public string City { get; set; }

        [Column(TypeName = "char(4)")]
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
