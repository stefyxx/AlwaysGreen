using AlwaysGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.DAL.Context
{
    public static class DataSeeders
    {
        public static IEnumerable<Emptybottle> InitEmptybottles() 
        {
            yield return new Emptybottle() { Id = 1, TypeName = "shampoo", Quantity = 10, Prix = 10};
            yield return new Emptybottle() { Id = 1, TypeName = "dishwashingLiquid", Quantity = 10, Prix = 10 };
            yield return new Emptybottle() { Id = 1, TypeName = "laundryDetergent", Quantity = 10, Prix = 10 };
            yield return new Emptybottle() { Id = 1, TypeName = "softener", Quantity = 10, Prix = 10 };
        }

        public static IEnumerable<Address> InitAddresses()
        {
            yield return new Address() { Id = 1, StreetName = "test", StreetNumber = "1", Apartment = null, Unit = null, UnitNumber = null, City = "Anverse", ZipCode = "2000", Country = "Belgique"};
            yield return new Address() { Id = 1, StreetName = "ste", StreetNumber = "1", Apartment = null, Unit = null, UnitNumber = null, City = "Bruxelles", ZipCode = "1000", Country = "Belgique" };
        }

        public static IEnumerable<Courier> InitCouriers()
        {
            yield return new Courier() {  Id = 1, Name = "steCourier", PhoneNumber = "+32234567", Email = "courierUser@test.com", VATnumber = "1234", IsActive = true, AddressId = InitAddresses().ToArray()[0].Id };
        }

    }
}
