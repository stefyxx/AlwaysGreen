using AlwaysGreen.Domain.Enums;

namespace AlwaysGreen.DTO
{
    public class LocationResultDTO
    {
        public int Id { get; set; }
        public string? AgencyName { get; set; }
        public string? CompanyName { get; set; }
        public virtual RolesEnum[] Roles { get; set; }
        public AddressDTO Address { get; set; }
        public string Username { get; set; }
    }
}
