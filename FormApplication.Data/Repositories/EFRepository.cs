using FormApplication.Data.Contexts;
using FormApplication.Data.Repositories;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly FormApplicationContext _context;

        private readonly DbSet<T> _dbSet;

        public EFRepository(FormApplicationContext context)
        {
            if (context == null)
                throw new ArgumentNullException("Context can not be null.");

            _context = context;
            try
            {
                _dbSet = context.Set<T>();
            }
            catch (Exception ex)
            {

            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            // _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            // _dbSet.Delete(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this._dbSet;
            }
        }

    }
}
