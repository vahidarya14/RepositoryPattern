using _2_DomainEntities;
using Repo.Framework;

namespace _4_UnitOfWork
{
    public interface IDbUnitOfWork : IUnitOfWork
    {
        IRepository<PersonEntity> People { get; }
    }
}