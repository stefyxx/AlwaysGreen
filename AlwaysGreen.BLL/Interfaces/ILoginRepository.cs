﻿using AlwaysGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.BLL.Interfaces
{
    public interface ILoginRepository
    {
        public Login? Get(string username);
        public Login Add(Login login);
        public Login? Find(int loginId);
        public List<Login> GetAll();
    }
}
