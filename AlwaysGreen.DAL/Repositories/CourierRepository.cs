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
    public class CourierRepository : BaseRepository<Courier>, ICourierRepository
    {
        public CourierRepository(AlwaysgreenContext context) : base(context) { }

        public List<Courier> GetAll()
        {
           return _table
                .Include(a=> a.Address)
                .Include(t=> t.Transports)
                .Where(c=> c.IsActive == true)
                .ToList();
        }

        public Courier? Find(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Courier? FindIsExisting(Courier e)
        {
            throw new NotImplementedException();
        }

        //Add--> é il Depot, la segretaria, che inserisce un courrier
        //--> role = Depot
        //NBBB sarà depot che deve controllare che la mail di Courrier non esista già in DB

        public void Delete(Courier e)
        {
            throw new NotImplementedException();
        }

    }
}
