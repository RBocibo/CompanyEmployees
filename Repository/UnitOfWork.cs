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

        public void Commit()
        {
            _repositoryContext.SaveChangesAsync();
        }
    }
}
