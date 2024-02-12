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
    public class EmptybottleRepository : BaseRepository<Emptybottle>, IEmptybottleRepository
    {
        public EmptybottleRepository(AlwaysgreenContext context) : base(context) { }

        public List<Emptybottle> GetAll()
        {
            return base.FindAll();
        }
        public Emptybottle? Find(params object[] id)
        {
            return base.FindById(id); //(int)id[0]
        }

        public void Delete(Emptybottle e)
        {
            _table.Remove(e);
            //base.Remove(e);
        }


        public Emptybottle? FindIsExisting(Emptybottle e)
        {
            //getAll --> ne dovrebbe trovare solo 1
            List<Emptybottle> tipesBottles = base.FindAll().Where(b=>
            b.TypeName == e.TypeName).ToList();

            if (tipesBottles.Count == 0) return null; //vuol dire che bisogna fare ADD new
            else if (tipesBottles.Count == 1) return tipesBottles[0];
            
            else
            {

                throw new Exception("ho troppi tipi di bottiglie UGUALI");
            }
        }

        
    }
}
