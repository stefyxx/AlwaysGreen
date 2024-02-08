using AlwaysGreen.BLL.Infrastructs;
using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.BLL.Templates;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class ParticularServices(IParticularRepository _particularRepository, IPasswordHasher _passwordHasher, IAddressRepisitory _addressRepository, ILoginRepository _loginRepository//,
        //HtmlRenderer _renderer, Mailer _mailer
        )
    {
        //getAll
        public List<Particular> GetAll()
        {
            return _particularRepository.GetAll();
        }

        public Particular Register(string FirstName, string LastName, string PhoneNumber, string Email,Address address, string password, string Username)
        {
            try
            {
                using TransactionScope transaction = new TransactionScope();

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
                    // TODO : controllare che login non esista già
                    Login l = _loginRepository.Add(new Login()
                    {
                        Username = Username,
                        Password = hash,
                        Roles = [RolesEnum.Particular],
                        ParticularId = p.Id
                    });

                    //particular creato, gli invio mail con Firstname+lastname, mail, vostro login é: Username, psw
                    //string html = _renderer.Render<Welcome>(
                    // new
                    // {
                    //     FirstName = p.FirstName,
                    //     LastName = p.LastName,
                    //     Email = p.Email,

                    //     Username = l.Username,
                    //     Psw = password
                    // }
                    // );
                    //_mailer.Send(p.Email, "Welcome among us", html);

                }
                else { throw new Exception(message:"particular mal inserito"); };

                transaction.Complete();
                return p;
            }
            catch (Exception)
            {
                throw new Exception("It was not possible to register");
            }

        }
    }
}
