using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlwaysGreen.DTO
{
    public class CourierDTO
    {
        public required string Name { get; set; }

        [Column(TypeName = "varchar(15)")]
        public required string PhoneNumber { get; set; }

        [Column(TypeName = "varchar(75)")]
        [EmailAddress]
        public required string Email { get; set; }

        //numéro de TVA
        public required string VATnumber { get; set; }

        public bool IsActive { get; set; }
        public AddressCreateDTO Address { get; set; }

    }
}
