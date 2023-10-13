﻿using FlowerParadiseAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlowerParadiseAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking=true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> filter, bool tracking=true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Update(T entity);
        Task<bool> Remove(string id);
        bool Remove(T model);
        bool RemoveRange(List<T> entities);
        Task<int> SaveAsync();
        
    }
}