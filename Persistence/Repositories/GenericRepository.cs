using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(
            ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> FindByIdAsync(Guid id, params string[] navigationProperties)
        {
            var query = ApplyNavigation(navigationProperties);
            T entity = await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
            return entity;
        }

        private IQueryable<T> ApplyNavigation(params string[] navigationProperties)
        {
            var query = _dbSet.AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);
            return query;
        }
        public virtual async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T _entity)
        {
            _dbSet.Remove(_entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> ListAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            List<T> list;
            var query = _dbSet.AsQueryable();
            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);//got to reaffect it.

            list = await query.Where(predicate).AsNoTracking().ToListAsync<T>();
            return list;
        }

        public virtual async Task UpdateAsync(T updated)
        {
            _context.Attach(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
