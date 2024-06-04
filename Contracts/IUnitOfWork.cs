namespace Contracts
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
