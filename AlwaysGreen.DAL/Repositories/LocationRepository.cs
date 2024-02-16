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
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        private readonly DbSet<Address> _addresses;
        public LocationRepository(AlwaysgreenContext context) : base(context) {
            _addresses = context.Addresses;
        }

        public List<Location> GetAll()
        {
            //error perché in context non ho DbSet di class abstract
            return _table
                .Include(a => a.Address)
                .Include(l => l.Login)
                .Where(t => t.IsActive == true)
                .OrderBy(t => t.Email)
                .ToList();
            //return base.FindAll().Join(_addresses, l => l.AddressId, a => a.Id, (l, a) =>
            //{
            //    l.Address = a;
            //    return l;
            //}).OrderBy(l => l.Email).ToList();
        }
    }
}
