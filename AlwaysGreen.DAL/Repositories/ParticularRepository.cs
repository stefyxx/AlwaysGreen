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
    public class ParticularRepository :BaseRepository<Particular>, IParticularRepository
    {
        public ParticularRepository(AlwaysgreenContext context) : base(context) { }

        public Particular? Find(params object[] id)
        {
            return _table
                .Include(a => a.Address)
                .Include(l=> l.Login)
                .FirstOrDefault(c => c.Id == (int)id[0]);
        }

        public List<Particular> GetAll()
        {
            //ONLY active --+ IsActive == true
            return _table
                .Include(a => a.Address)
                .Where(t => t.IsActive == true)
                .ToList();
        }

        //non serve, add lo fa perché 'entity contiene le FK
        //public Particular? Insert(Particular entity, int AddressId, int LoginId)
        //{
        //    //return base.Add(entity);

        //    //_context.SaveChanges();
        //    return _table
        //        .Include(a => a.Address)
        //        .Where(t => t.AddressId == AddressId)
        //        .Include(l => l.Login)
        //        .Where(l=> l.LoginId == LoginId)
        //        .FirstOrDefault();
        //}

        //non serve, p contiene le FK
        //public override void Update(Particular p)
        //{
        //    _table
        //        .Include(a => a.Address).Where(a=> a.AddressId == p.AddressId)
        //        .Include(l => l.Login).Where(l=> l.LoginId == p.LoginId)
        //        .ExecuteUpdate(p);

        //    _context.SaveChanges();
        //}
        
        //recupero p con Id perché é preso dal User connected
        public Particular? myUpdate(Particular p, string username, string email, int addressId, string phoneNumber, byte[] psw)
        {
            p.Email = email;
            p.AddressId = addressId;
            p.PhoneNumber = phoneNumber;
            p.Login.Username = username;
            p.Login.Password = psw;
            Update(p);

            //return p;

            //x essere sicuri che ha cambiato
            Particular? updatedp = Find(p.Id);
            if (updatedp != null) return updatedp;
            else throw new Exception("It was not possible to modify yours datas");

            //Particular? newp = _table
            //   .Include(a => a.Address).Where(t => t.AddressId == AddressId)
            //   .Include(l => l.Login).Where(l=> l.LoginId == LoginId) 
            //   .Where(pa => p.Id == pa.Id)
            //   .FirstOrDefault();
            //if (newp != null)
            //{
            //    _context.SaveChanges();
            //    return newp;
            //}
            //else throw new Exception("It was not possible to modify yours datas");
        }
    }
}
