using System.ComponentModel.DataAnnotations.Schema;

namespace AlwaysGreen.DTO
{
    public class CourierDTO
    {
        public string Name { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Email { get; set; }

        //numéro de TVA
        public string VATnumber { get; set; }

        public bool IsActive { get; set; }
        public AddressDTO Address { get; set; }

    }
}
