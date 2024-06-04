using Repository;

namespace Contracts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _repositoryContext;

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Task CommitAsync()
        {
            return _repositoryContext.SaveChangesAsync();
        }
    }
}
