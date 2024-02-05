using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.DAL.Context
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _table; // per evitare di scrivere sempre _context.Set<T>
        public BaseRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public virtual TEntity? FindById(params object[] id)
        {
            return _context.Set<TEntity>().Find(id);

        }

        public virtual List<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity Add(TEntity entity)
        {
            TEntity inserted = _context.Set<TEntity>().Add(entity).Entity;
            _context.SaveChanges();
            return inserted;
        }

        public virtual void Remove(TEntity entity)
        {
            //_context.Set<TEntity>().Remove(entity);       //lui capisce dove
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            //_context.Set<TEntity>().Update(entity);       //lui capisce dove
            _table.Update(entity);
            _context.SaveChanges();
        }

    }
}
