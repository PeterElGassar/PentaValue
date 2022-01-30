using Api.Models;
using Api.Persistence.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Persistence.Repositories
{
    public class MainRepository<T> :IRepository<T> where T :class
    {

        private readonly Context _context;

        internal DbSet<T> dbSet;


        public MainRepository(Context context)
        {
            _context = context;

            dbSet = _context.Set<T>();

        }



        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
             string includeProperties)
        {
            IQueryable<T> query = dbSet;

            //to Add Related Objects
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();

        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProperties)
        {
            IQueryable<T> query =  dbSet;

            //to Add Related Objects
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (filter != null)
                query = query.Where(filter);

            return query.FirstOrDefault();
        }

         public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties)
        {
             IQueryable<T> query =  dbSet;

            //to Add Related Objects
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query =  query.Include(includeProp);
                }
            }

            if (filter != null)
                query =  query.Where(filter);

            return  await query.FirstOrDefaultAsync();
        }




        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

      
    }
}
