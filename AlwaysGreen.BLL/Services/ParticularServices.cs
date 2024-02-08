using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.BLL.Services
{
    public class ParticularServices(IParticularRepository _particularRepository, IPasswordHasher _passwordHasher, IAddressRepisitory _addressRepository, ILoginRepository _loginRepository)
    {
        //getAll
        public List<Particular> GetAll()
        {
            return _particularRepository.GetAll();
        }

        public Particular Register(string FirstName, string LastName, string PhoneNumber, string Email,Address address, string password, string Username)
        {
            byte[] hash = _passwordHasher.Hash(Email + password);

            //Add inserisce e ritorna Entity con id --> 
            // prima controllo che non esista già
            Address? addressExisting = _addressRepository.FindIsExisting(address);
            Address a = new Address();
            if (addressExisting == null)
            {
                a = _addressRepository.Add(new Address()
                {
                    // Id dato da inserted
                    StreetName = address.StreetName,
                    StreetNumber = address.StreetNumber,
                    Apartment = address.Apartment ??  null,
                    Unit = address.Unit ?? null,
                    UnitNumber = address.UnitNumber ?? null,
                    City = address.City,
                    ZipCode = address.ZipCode,
                    Country = address.Country
                });
            }


            Particular p = _particularRepository.Add(new Particular 
            { 
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                IsActive = true,
                Email = Email,
                //Roles = [RolesEnum.Particular], --> lo fa automaticamente C# --> NO INTO DB --> TODO: puo' dare problemi? ho login che ce l'ha
                AddressId = (addressExisting is null) ? a.Id : addressExisting.Id, //addressExisting.Id ?? a.Id,
                Address = (addressExisting is null)? a : addressExisting, //indirizzo inserito, con buon Id
            });

            //se riesco a inserire un particular, posso creare il login 
            if(p.Id > 0) 
            {
                Login l = _loginRepository.Add(new Login()
                {
                    Username = Username,
                    Password = hash,
                    Roles = [RolesEnum.Particular],
                    ParticularId = p.Id
                });
            }
            else { throw new Exception(message:"particular mal inserito"); };

            return p;
        }
    }
}
