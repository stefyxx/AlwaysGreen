using AlwaysGreen.BLL.Interfaces;
using AlwaysGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.DAL.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Login? Get(string username)
        {
            throw new NotImplementedException();
        }
    }
}
