using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AlwaysGreen.BLL.Services
{
    public class CourierServices(ICourierRepository _courierRepository, CommonServices _commonServices)
    {
        public List<Courier> GetAll() { return _courierRepository.GetAll();}

        public Courier Register(string name, string phoneNumber, string email, string VATnumber, Address address)
        {
            //SOLO Depot potrà accedere al method nel controller
            try
            {
                //1- controllare che email non sia già in DB
                bool isEmailExsisted = _commonServices.IsExistedEmail(email);
                if (isEmailExsisted) throw new Exception("The email exists into DB");
                //2- creare Courrier
                Courier newCourrier = new Courier()
                {
                    Name = name,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    VATnumber = VATnumber,
                    IsActive= true,
                    Address = _commonServices.FindOrCreateAddress(address),
                };
                Courier c = _courierRepository.Add(newCourrier);
                return c;
                //email ?
            }
            catch (Exception ex)
            {
                throw new Exception("non é stato possibile inseire il corriere");
            }

        }

        public void Delete(int id)
        {
            Courier? c = _courierRepository.Find(id);
            if (c != null)
            {
                c.IsActive = false;
                _courierRepository.Update(c);

            }
            else { throw new Exception(); }
            //else { throw new KeyNotFoundException(); }
        }

        public Courier? MyUpdate(int? idRoute,int Id, string name, string phoneNumber, string email, string VATnumber, Address address)
        {
            if (idRoute != 0 || idRoute != Id) throw new Exception("id route diverso da id Entity");
            else if (idRoute == 0 || idRoute == Id)
            {
                Courier c = _courierRepository.Find(Id);
                c.Name = name;
                c.PhoneNumber = phoneNumber;

                //controllo email
                if(c.Email == email) { c.Email = email; }
                else
                {
                    bool isEmailExsisted = _commonServices.IsExistedEmail(email);
                    if (isEmailExsisted) throw new Exception("The email exists into DB");
                    else { c.Email = email; }
                }

                c.VATnumber = VATnumber;
                c.Address = _commonServices.FindOrCreateAddress(address);
                _courierRepository.Update(c);
                return c;
            }
            else
            {
                //(idRoute == 0 || idRoute != Id)
                throw new Exception("id route diverso da id Entity");
            }
        }

    }
}
