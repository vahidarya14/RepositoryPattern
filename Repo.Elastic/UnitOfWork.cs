using _2_DomainEntities;
using _4_UnitOfWork;
using Repo.Framework;

namespace Repo.Elastic
{
    public class UnitOfWork : IDbUnitOfWork
    {
        public UnitOfWork(Nest.ElasticClient database)
        {
            People = new PersonRepository(database);
        }

        public IRepository<PersonEntity> People { get; private set; }

        public Task<int> SavechangesAsync() => Task.FromResult(1);

    }

}
