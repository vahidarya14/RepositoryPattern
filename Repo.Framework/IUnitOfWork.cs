

namespace Repo.Framework
{
    public interface IUnitOfWork
    {
        Task<int> SavechangesAsync();
    }
}
