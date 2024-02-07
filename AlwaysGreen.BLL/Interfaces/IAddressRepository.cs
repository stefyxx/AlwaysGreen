using AlwaysGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface IAddressRepisitory
    {
        Address Add(Address address);
        void Update(Address address);
        void Delete(Address address);
        Address? Find(params object[] id);
    }
}
