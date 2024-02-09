using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.DAL.Context;
using AlwaysGreen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.DAL.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepisitory
    {
        public AddressRepository(AlwaysgreenContext context) : base(context) { }

        public void Delete(Address address)
        {
            _table.Remove(address);
        }

        public Address? Find(params object[] id)
        {
            return base.FindById(id);
        }

        public Address? FindIsExisting(Address address)
        {
            //first: controll with StreetName + StreetNumber + City + Country
            List<Address>? addresses = base.FindAll().Where(a => (a.Country == address.Country && a.City == address.City && a.StreetName == address.StreetName && a.StreetNumber == address.StreetNumber)).ToList();
            if (addresses.Count > 0)
            {
                //Any --> NOT has ToList()

                //second: controll with Apartment, Unit, UnitNumber
                List<Address>? aadd = addresses.Where(a => (a.Apartment == address.Apartment && a.Unit == address.Unit && a.UnitNumber == address.UnitNumber)).ToList();
                if (aadd.Count <= 0) return null; 
                if(aadd.Count == 1) return aadd[0];
                else throw new Exception(message: "ho troppi indirizzi UGUALI");
            }
            else
            {
                return null;
            }
        }

    }
}

