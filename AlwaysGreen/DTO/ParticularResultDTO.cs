using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using AlwaysGreen.Functions;

namespace AlwaysGreen.DTO
{
    public class ParticularResultDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public RolesEnum[] Roles { get; set; }
        public bool IsActive { get; set; }

        public AddressDTO Address { get; set; }


    }
}
