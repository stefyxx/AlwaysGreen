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

        public static Particular toDAL(this RegisteredParticularDTO p)
        {
            return new Particular()
            {

            };
        }
    }

}
