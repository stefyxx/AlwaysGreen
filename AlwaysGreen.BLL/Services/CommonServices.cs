using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class CommonServices(
        ILocationRepository _locationRepository,
        IParticularRepository _particularRepository,
        ICourierRepository _courierRepository,
        ILoginRepository _loginRepository,
        IAddressRepisitory _addressRepository,
        ISiretRepository _siretRepository
        )
    {
        public bool IsExistedEmail(string newEmail)
        {
            List<string> allEmails = new List<string>();

            List<Location> allLocations = _locationRepository.GetAll();
            allLocations.ForEach(l => { allEmails.Add(l.Email); });
            List<Particular> allParticular = _particularRepository.GetAll();
            allParticular.ForEach(p => { allEmails.Add(p.Email); });
            List<Courier> allCouriers = _courierRepository.GetAll();
            allCouriers.ForEach(c => { allEmails.Add(c.Email); });

            if (allEmails != null)
            {
                if(allEmails.Contains(newEmail)) return true;
                else return false;
            }
            else return false;
        }
        public bool IsExistedUsernameOrPsw(string newUsername, byte[] newPswHashed)
        {
            List<Login> allLogins = _loginRepository.GetAll();
            List<string> allUsername = allLogins.Select(l => l.Username).ToList();
            List<byte[]> allPswHashed = allLogins.Select(l => l.Password).ToList();
            if (allUsername.Count > 0)
            {
                if(allUsername.Contains(newUsername)) return true;
                else return false;
            }
            else if(allPswHashed.Count > 0)
            {
                if(allPswHashed.Contains(newPswHashed)) return true;
                else return false;
            }
            else return false;
        }

        public Address FindOrCreateAddress(Address address)
        {
            Address? addressExisting = _addressRepository.FindIsExisting(address);
            Address a = new Address();
            if (addressExisting == null)
            {
                a = _addressRepository.Add(new Address()
                {
                    // Id dato da inserted
                    StreetName = address.StreetName,
                    StreetNumber = address.StreetNumber,
                    Apartment = address.Apartment ?? null,
                    Unit = address.Unit ?? null,
                    UnitNumber = address.UnitNumber ?? null,
                    City = address.City,
                    ZipCode = address.ZipCode,
                    Country = address.Country
                });
                return a;
            }
            else return addressExisting;
        }
        public Siret FindOrCreateSiret(Siret siret)
        {
            Siret s = new Siret();
            if(siret == null)
            {
                throw new ArgumentNullException("inserire un SIRET");
            }
            else
            {
                Siret? siretExisting = _siretRepository.FindIsExisting(siret);
                if (siretExisting == null) 
                {
                    s = _siretRepository.Add(new Siret() 
                    { 
                        Siren = siret.Siren,
                        NIC = siret.NIC
                    });
                    return s;
                }
                else return siretExisting;
            }
        }

        public Login CreateLogin(string newUsername, byte[] newPswHashed, RolesEnum role)
        {
            //using TransactionScope transaction = new TransactionScope();
            //1- controllo che non esista già
            //in realtà NON dovrebbe perché Username e Psw devono essere unici
            Login? oldLogin = _loginRepository.Get(newUsername);
            if (oldLogin != null && oldLogin.Password == newPswHashed) 
            {
                throw new Exception("esiste già un login con queste credenziali");
            }
            
            ////2- Add() login con il buon role
            //Login l = _loginRepository.Add(new Login()
            //{
            //    Username = newUsername,
            //    Password = newPswHashed,
            //    Roles = [role],
            //});

            //transaction.Complete();
            return new Login()
            {
                Username = newUsername,
                Password = newPswHashed,
                Roles = [role],
            };
        }

    }
}
