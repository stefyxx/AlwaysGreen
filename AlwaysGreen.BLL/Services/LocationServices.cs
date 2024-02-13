using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using Microsoft.AspNetCore.Components.Web;
using System.Transactions;

namespace AlwaysGreen.BLL.Services
{
    public class LocationServices (ILocationRepository _locationRepository,
        IPasswordHasher _passwordHasher,
        //IAddressRepisitory _addressRepository, 
        ILoginRepository _loginRepository,
        HtmlRenderer _renderer, IMailer _mailer,
        CommonServices _commonServices,
        IDepotRepository _depotRepository,
        ICompanyRepository _companyRepository, IStoreRepository _storeRepository
        )
    {
        public List<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public Location Register(
            string? agencyName, string?companyName, string phoneNumber,RolesEnum[] roles, string email,
            Address address, string password, string username, string? VATnumber, Siret siret, 
            bool isPickUpPoint, bool isStorePoint)
        {
            try
            {
                //using TransactionScope transaction = new TransactionScope();
                byte[] newPswHashed = _passwordHasher.Hash(email + password);

                //1- controllare che username e/o psw non siano gà in DB
                bool isPswOrUsernam = _commonServices.IsExistedUsernameOrPsw(username, newPswHashed);
                if (isPswOrUsernam) { throw new Exception("password or Username exsist into DB"); }
                // else username ET newPswHashed posso usarle nell' Add()

                //2- controllare che email non sia già in DB
                bool isEmailExsisted = _commonServices.IsExistedEmail(email);
                if (isEmailExsisted) throw new Exception("The email exists into DB");

                //address: creare o recuperare
                Address a = _commonServices.FindOrCreateAddress(address);


                //mettere Role in base alla class
                if (roles.Contains(RolesEnum.Company))
                {
                    //creare Login in base al ruolo
                    Login l = _commonServices.CreateLogin(username, newPswHashed, RolesEnum.Company);
                    //Siret
                    Siret newSiret = _commonServices.FindOrCreateSiret(siret);
                    //creamo una Company: first creamo
                    Company c = _companyRepository.Add(new Company()
                    {
                        AgencyName = agencyName,
                        CompanyName = companyName,
                        PhoneNumber= phoneNumber,
                        Email= email,
                        //Roles = [RolesEnum.Company],
                        IsActive = true,
                        AddressId = a.Id,
                        LoginId = l.Id,
                        VATnumber = VATnumber ?? null,
                        SiretId = newSiret.Id,
                    });
                    return c;
                }
                else if(roles.Contains(RolesEnum.Store))
                {
                    Login l = _commonServices.CreateLogin(username, newPswHashed, RolesEnum.Store);
                    //Siret
                    Siret newSiret = _commonServices.FindOrCreateSiret(siret);
                    Store s = _storeRepository.Add(new Store() 
                    {
                        AgencyName = agencyName,
                        CompanyName = companyName,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        //Roles = [RolesEnum.Store],
                        IsActive = true,
                        AddressId = a.Id,
                        LoginId = l.Id,
                        VATnumber = VATnumber ?? null,
                        IsPickUpPoint = isPickUpPoint,
                        IsStorePoint = isStorePoint,
                        SiretId = newSiret.Id,

                    });
                    return s;
                }
                else if (roles.Contains(RolesEnum.Depot))
                {
                    Login l = _commonServices.CreateLogin(username, newPswHashed, RolesEnum.Depot);
                    Depot d = _depotRepository.Add(new Depot()
                    {
                        AgencyName = agencyName,
                        CompanyName = companyName,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        //Roles = [RolesEnum.Depot],
                        IsActive = true,
                        AddressId = a.Id,
                        LoginId = l.Id,

                    });
                    return d;
                }
                else { throw new Exception(); }

                //spedizione mail
                //if (p.Id > 0)
                //{

                //    //particular creato, gli invio mail con Firstname+lastname, mail, vostro login é: Username, psw
                //    //string html = _renderer.Render<Welcome>(
                //    // new
                //    // {
                //    //     FirstName = p.FirstName,
                //    //     LastName = p.LastName,
                //    //     Email = p.Email,

                //    //     Username = l.Username,
                //    //     Psw = password
                //    // }
                //    // );
                //    //_mailer.Send(p.Email, "Welcome among us", html);

                //}
                //else { throw new Exception(message: "particular mal inserito"); };

                //transaction.Complete();
                //return c ?? s ?? d ?? null;

            }
            catch (Exception)
            {
                throw new Exception("Non é stato possibile inserire l'utente-location");
            }

        }
    }
}
