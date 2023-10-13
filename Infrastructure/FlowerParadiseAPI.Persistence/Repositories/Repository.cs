using FlowerParadiseAPI.Application.Repositories;
using FlowerParadiseAPI.Domain.Entities.Common;
using FlowerParadiseAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FlowerParadiseAPI.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly FlowerParadiseDbContext _context;

        public Repository(FlowerParadiseDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;

        }

        public async Task<bool> Remove(string id)
        {
            var query = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            EntityEntry entityEntry = Table.Remove(query);
            return entityEntry.State == EntityState.Deleted;
        }
        public  bool Remove(T Model)
        {
            EntityEntry entityEntry = Table.Remove(Model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

        }

        public async Task<T> GetSingleAsync(Expression<Func<T,bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter);
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return query;
        }

        public  async Task<int> SaveAsync()
       
           => await _context.SaveChangesAsync();
        

        public bool Update(T entity)
        {
            EntityEntry entityEntry =  Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
