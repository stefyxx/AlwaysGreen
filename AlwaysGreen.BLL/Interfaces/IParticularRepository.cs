﻿using AlwaysGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlwaysGreen.BLL.Interfaces
{
    public interface IParticularRepository
    {
        public List<Particular> GetAll();

        public Particular Add(Particular p);
    }
}