using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace AlwaysGreen.DTO
{
    public class LocationRegisteredDTO
    {
        //Depot : AgencyName
        //Store: AgencyName + CompanyName
        //Company: CompanyName
        public string? AgencyName { get; set; }
        public string? CompanyName { get; set; }
        public required string PhoneNumber { get; set; }
        public required RolesEnum[] Roles { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required AddressCreateDTO Address { get; set; }
   
        //login
        public required string Password { get; set; }
        [RegexStringValidator("^[a-zA-Z][a-zA-Z0-9]{3,9}$")]
        public required string Username { get; set; }

        //not in Depot
        public string? VATnumber { get; set; }

        public SiretDTO? Siret { get; set; }
        public bool IsPickUpPoint { get; set; }
        public bool IsStorePoint { get; set; }

    }
}
