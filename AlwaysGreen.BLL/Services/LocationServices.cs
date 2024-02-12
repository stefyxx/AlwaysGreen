using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using Microsoft.AspNetCore.Components.Web;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class LocationServices (ILocationRepository _locationRepository,
        IPasswordHasher _passwordHasher,
        IAddressRepisitory _addressRepository, 
        ILoginRepository _loginRepository,
        HtmlRenderer _renderer, IMailer _mailer)
    {
        public List<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public Location Register(
            string? agencyName, string?companyName,
            string phoneNumber,RolesEnum[] roles, string email,
            Address address, string password, string username,
            string? VATnumber, Siret siret, 
            bool isPickUpPoint, bool isStorePoint)
        {
            try
            {
                using TransactionScope transaction = new TransactionScope();
                //registrazione --> Add
                byte[] hash = _passwordHasher.Hash(email + password);
                //find all email
                //find all pwshashed
                List<Location> locations = GetAll();
                locations.Select(location=> location.Email = email);




                //isActive = true
                //mettere Role in base alla class
                //creare Login = mail
                //address: creare o recuperare


                //spedizione mail


                transaction.Complete();
                return;

            }
            catch (Exception)
            {
                throw new Exception("L'email n'a pas pu être envoyé");
            }

        }
    }
}
