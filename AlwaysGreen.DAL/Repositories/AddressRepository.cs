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
    }
}
