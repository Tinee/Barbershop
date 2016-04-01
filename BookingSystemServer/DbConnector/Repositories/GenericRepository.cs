using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DbConnector.DataAccessLayer;
using System.Data.SqlClient;

namespace DbConnector.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private BookingContext _context;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(object context)
        {
            this._context = (BookingContext)context;
            this._dbSet = _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""
            )
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Delete(int id)
        {
            var entity = _dbSet.Find(id);
            return Delete(entity);
        }

        public bool Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            return Save();
        }


        public bool Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
              return Save();
        }

        public bool Edit(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
