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
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AlwaysgreenContext context) : base(context) { }

        //public override Company Add(Company c)
        //{
        //    c base.Add(entity);
        //    ////Company? company =  
        //    //var company = _table
        //    //.Include(a => a.Address).Where(a => a.AddressId == c.AddressId)
        //    //.Include(l => l.Login).Where(l => l.LoginId == c.LoginId)
        //    //.Include(s => s.Siret).Where(s => s.SiretId == c.SiretId);

        //    _context.SaveChanges();
        //    //return company.FirstOrDefault();
        //}
    }
}
