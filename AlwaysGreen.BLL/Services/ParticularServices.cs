using AlwaysGreen.BLL.Infrastructs;
using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.BLL.Templates;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class ParticularServices(
        IParticularRepository _particularRepository, IPasswordHasher _passwordHasher, 
        IAddressRepisitory _addressRepository, ILoginRepository _loginRepository,
        HtmlRenderer _renderer, IMailer _mailer
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

                // TODO : controllare che login non esista già
                Login l = _loginRepository.Add(new Login()
                {
                    Username = Username,
                    Password = hash,
                    Roles = [RolesEnum.Particular],
                    //Particular = p,
                });

                Particular p = _particularRepository.Add(new Particular 
                { 
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    IsActive = true,
                    Email = Email,
                    //Roles = [RolesEnum.Particular], --> lo fa automaticamente C# --> NO INTO DB --> TODO: puo' dare problemi? ho login che ce l'ha
                    AddressId = (addressExisting == null) ? a.Id : addressExisting.Id, //addressExisting.Id ?? a.Id,
                    //Address = (addressExisting == null)? a : addressExisting, //indirizzo inserito, con buon Id
                    LoginId = l.Id,
                });

                //se riesco a inserire un particular, posso creare il login 
                if(p.Id > 0) 
                {
                   
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

        public Particular? Find(params object[] id) 
        {
            return _particularRepository.Find(id);
        }
        public Particular? FindWithLoginId(int LoginId) 
        {
            Login? logged = _loginRepository.Find(LoginId);
            if(logged == null) return null;
            else return _particularRepository.Find(logged.Particular.Id);
            
        }


        //override methode update
        public void Update(Particular particular)
        {
            _particularRepository.Update(particular);
        }

        public Particular? FirstUpdate(int loginId, Address newAddress)
        {
            try
            {
                using TransactionScope transaction = new TransactionScope();

                Particular? p = FindWithLoginId(loginId);
                if (p != null)
                {
                    Address? addressExisting = _addressRepository.FindIsExisting(newAddress);
                    Address a = new Address();
                    if (addressExisting == null)
                    {
                        a = _addressRepository.Add(new Address()
                        {
                            // Id dato da inserted
                            StreetName = newAddress.StreetName,
                            StreetNumber = newAddress.StreetNumber,
                            Apartment = newAddress.Apartment ?? null,
                            Unit = newAddress.Unit ?? null,
                            UnitNumber = newAddress.UnitNumber ?? null,
                            City = newAddress.City,
                            ZipCode = newAddress.ZipCode,
                            Country = newAddress.Country
                        });
                    }
                    transaction.Complete();
                    return p;
                }
                else { throw new Exception(message: "No user found"); };
            }
            catch (Exception) { throw new Exception("It was not possible to update"); }

        }
        public Particular? myUpdate(Particular particular, string username, string email, int addressId, string phoneNumber, string psw, string cancelLink)
        {
            byte[] hash = _passwordHasher.Hash(email + psw);

            Particular? p = _particularRepository.myUpdate(particular, username, email, addressId, phoneNumber, hash);
            if(p != null)
            {
                //particular updated-->  mail 

                //string html = _renderer.Render<GoodUpdate>(
                // new
                // {
                //     FirstName = p.FirstName,
                //     LastName = p.LastName,
                //     Email = p.Email,
                //     address = p.Address,
                //     Username = p.Login.Username,
                //     Psw = psw,
                //     CancelLink = cancelLink
                // }
                // );
                //_mailer.Send(p.Email, "Updated data", html);

            }

            return p == null ? null : p;
        }
    }
}
