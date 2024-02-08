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

        public Particular? Find(params object[] id)
        {
            return _table
                .Include(a => a.Address)
                .Include(l=> l.Logins)
                .FirstOrDefault(c => c.Id == (int)id[0]);
        }

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

            //_context.SaveChanges();
            return _table
                .Include(a => a.Address)
                .Where(t => t.AddressId == AddressId)
                .Include(l => l.Logins.First(l => l.Id == LoginId))
                .FirstOrDefault();
        }

        public override void Update(Particular p)
        {
            _table
                .Include(a => a.Address)
                .Include(l => l.Logins);

            _context.SaveChanges();
        }
    }
}
