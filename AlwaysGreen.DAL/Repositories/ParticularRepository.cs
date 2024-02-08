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
    public class ParticularRepository :BaseRepository<Particular>, IParticularRepository
    {
        public ParticularRepository(AlwaysgreenContext context) : base(context) { }

        public List<Particular> GetAll()
        {
            //ONLY active --+ IsActive == true
            return _table
                .Include(a => a.Address)
                .Where(t => t.IsActive == true)
                .ToList();
        }

        public Particular? Insert(Particular entity, int AddressId, int LoginId)
        {
            //return base.Add(entity);
            //first add address e recuperi Id
            //poi inserisci particular


            return _table
                .Include(a => a.Address)
                .Where(t => t.AddressId == AddressId)
                //.Include(l => l.  .Equals(LoginId))
                .FirstOrDefault();
        }
    }
}
