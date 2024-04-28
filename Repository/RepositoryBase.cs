using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(RepositoryContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async void DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var toBeRemoved = await _dbSet.Where(expression).ToListAsync();
            if (toBeRemoved == null)
                return;

            _dbSet.RemoveRange(toBeRemoved);
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<IQueryable<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
