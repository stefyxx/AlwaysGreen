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
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(AlwaysgreenContext context) : base(context){ }

        public Login? Get(string username) // + psw
        {
            return _table.FirstOrDefault(l => l.Username == username);
        }
        public override Login Add(Login entity)
        {
            //return base.Add(entity);
            if(entity.Particular != null)
            {
                _table.Include(p => p.Particular);
                _context.SaveChanges();
            }
            if(entity.Depot != null)
            {
                _table .Include(p => p.Depot);
                _context.SaveChanges();
            }
            return base.FindById(entity.Id);
                
        }
    }
}
