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
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }

        #region nb:
        //a volte hai Apartment --> corrisp a 13A
        //altre hai unit + unitnb --> ipercondomini
        public string? Apartment { get; set; }
        public string? Unit { get; set; }
        public string? UnitNumber { get; set; }
        #endregion
        public string City { get; set; }

        [Column(TypeName = "char(4)")]
        public string ZipCode { get; set; }
        public string Country { get; set; }

        #region FK: aggiunte SOLO per far funzionare bene l'Include()

        public List<Location> Locations { get; set; }
        public List<Particular> Particulars { get; set; }
        public List<Courier> Couriers { get; set; }

        #endregion

    }
}
