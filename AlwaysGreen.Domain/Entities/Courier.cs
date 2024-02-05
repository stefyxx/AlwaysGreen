using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.Domain.Entities
{
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Email { get; set; }

        //numéro de TVA
        public string VATnumber { get; set; }

    }
}
