

namespace Repo.Framework
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync( CancellationToken ct);
    }
}
