using AlwaysGreen.Domain.Entities;
using AlwaysGreen.DTO;

namespace AlwaysGreen.Functions
{
    public static class Mappers
    {
        public static AddressDTO ToDTO(this Address data)
        {
            AddressDTO converson = new AddressDTO()
            {
                Id = data.Id,
                StreetName = data.StreetName,
                StreetNumber = data.StreetNumber,
                Apartment = data.Apartment ?? null,
                Unit = data.Unit ?? null,
                UnitNumber = data.UnitNumber ?? null,
                City = data.City,
                ZipCode = data.ZipCode,
                Country = data.Country
            };
            return converson;
        }
        public static Address ToDomain(this AddressCreateDTO data)
        {
            if (data is null) return null;
            return new Address()
            {
                Id = 0,
                StreetName = data.StreetName,
                StreetNumber = data.StreetNumber,
                Apartment = data.Apartment ?? null,
                Unit = data.Unit ?? null,
                UnitNumber = data.UnitNumber ?? null,
                City = data.City,
                ZipCode = data.ZipCode,
                Country = data.Country
            };
        }

        public static Siret ToDomain(this SiretDTO data)
        {
            if (data is null) return null;
            return new Siret()
            {
                Id = 0,
                Siren = data.Siren,
                NIC = data.NIC
            };
        }

        public static ParticularResultDTO ToDTO(this Particular d)
        {
            return new ParticularResultDTO()
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                PhoneNumber = d.PhoneNumber,
                Email = d.Email,
                Roles = d.Roles,
                IsActive = d.IsActive,
                Address = d.Address.ToDTO()

            };
        }

        public static LocationResultDTO ToDTO(Location data)
        {
            return new LocationResultDTO()
            {
                Id = data.Id,
                AgencyName= data.AgencyName,
                CompanyName= data.CompanyName,
                Roles = data.Roles.ToArray(),
                Address = data.Address.ToDTO(),
                Username = data.Login.Username,
            };
        }

        public static Emptybottle ToDomain(this EmptybottleTransportedDTO e)
        {
            return new Emptybottle()
            {
                TypeName = e.TypeName,
                Quantity = e.Quantity,
            };
        }
    }

}
