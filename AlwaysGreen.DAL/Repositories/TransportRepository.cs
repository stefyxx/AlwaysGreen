using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.DAL.Context;
using AlwaysGreen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.DAL.Repositories
{
    public class TransportRepository : BaseRepository<Transport>, ITransportRepository
    {
        private readonly DbSet<Address> _addresses;
        public TransportRepository(AlwaysgreenContext context) : base(context) 
        {
            _addresses = context.Addresses;
        }
        public List<Transport> GetAll()
        {
            return _table
               .Include(t => t.Deliveries)
               .Include(t => t.Emptybottles)
               .Include(t => t.LocationFrom)
               .ThenInclude(l => l.Address)
               .Include(t => t.LocationTo)
               .ThenInclude(l => l.Address)
               .Include(t => t.Courier)
               .ThenInclude(c => c.Address)
               .ToList();
        }
        public Transport? Find(params object[] id)
        {
            return _table
                .Include(t => t.Deliveries)
                .Include(t => t.Emptybottles)
                .Include(t => t.LocationFrom)
                .ThenInclude(l => l.Address)
                .Include(t => t.LocationTo)
                .ThenInclude(l => l.Address)
                .Include(t => t.Courier)
                .ThenInclude(c => c.Address)
                .Where(t => t.Id == (int)id[0]).FirstOrDefault();
        }

        public void Delete(Transport transport)
        {
            _table.Remove(transport);
        }


        public Transport? FindIsExisting(Transport transport)
        {
            throw new NotImplementedException();
        }

    }
}
