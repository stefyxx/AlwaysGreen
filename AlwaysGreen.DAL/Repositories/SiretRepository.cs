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
    public class SiretRepository : BaseRepository<Siret>, ISiretRepository
    {
        public SiretRepository(AlwaysgreenContext context) : base(context) { }

        public void Delete(Siret siret)
        {
            _table.Remove(siret);
        }

        public Siret? Find(params object[] id)
        {
            return base.FindById(id);
        }

        public Siret? FindIsExisting(Siret siret)
        {
            List<Siret>? sirets = base.FindAll().Where(s => (s.Siren == siret.Siren && s.NIC == siret.NIC)).ToList();
            if(sirets.Count == 1) return sirets[0];
            if(sirets.Count == 0) return null;
            else throw new Exception(message: "ho troppi Siret UGUALI");
        }

        public List<Siret> GetAll()
        {
            return base.FindAll();
        }
    }
}
