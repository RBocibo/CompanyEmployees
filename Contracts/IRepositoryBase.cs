using System.Linq.Expressions;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);
    }
}
