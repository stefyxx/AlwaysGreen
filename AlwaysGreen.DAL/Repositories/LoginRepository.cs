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

        public Login? Get(string username)
        {
            throw new NotImplementedException();
        }
    }
}
