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
    public class DepotRepository : BaseRepository<Depot>, IDepotRepository
    {
        public DepotRepository(AlwaysgreenContext context) : base(context) { }

    }
}
