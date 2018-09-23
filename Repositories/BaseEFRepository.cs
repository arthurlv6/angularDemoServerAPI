using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories.Context.Entities;
using Repositories.Entities;

namespace Repositories
{
    public abstract class BaseEFRepository<T> where T : BaseEntity
    {
        private bool _disposed;
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseEFRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();

                    _disposed = true;
                }
            }
        }

        protected IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        protected virtual IQueryable<T> GetQueryUnfiltered()
        {
            return _dbSet.AsQueryable();
        }

        protected virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        protected virtual void AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        protected virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        protected virtual void UpdateRange(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        protected virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        protected virtual void RemoveRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        protected async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
