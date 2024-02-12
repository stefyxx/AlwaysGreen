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

        public Login? Find(int loginId)
        {
            Login? l = base.FindById(loginId);
            if (l != null)
            {
                if (l.Roles.Contains(Domain.Enums.RolesEnum.Particular))
                {
                    return _table.Include(p => p.Particular).Where(l => l.Id == loginId).FirstOrDefault();
                }
                else return _table.Include(d => d.Depot).Where(l => l.Id == loginId).FirstOrDefault();

            }
            else { return null; }

        }

        public Login? Get(string username) // + psw
        {
            //return _table.Include(p => p.Particular)
            //    .Include(d => d.Depot)
            //    .FirstOrDefault(l => l.Username == username);

            Login? l = _table.FirstOrDefault(l => l.Username == username);
            if (l != null)
            {
                if (l.Roles.Contains(Domain.Enums.RolesEnum.Particular))
                {
                    return _table.Include(p => p.Particular).Where(p=> p.Username == username).FirstOrDefault();
                }
                else return _table.Include(d => d.Depot).Where(p => p.Username == username).FirstOrDefault();

            }
            else { return null; }
        }

    }
}
