﻿using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
    }
}
