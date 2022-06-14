using _2_DomainEntities;
using _4_UnitOfWork;
using MongoDB.Driver;
using Repo.Framework;

namespace Repo.MongoDb
{
    public class UnitOfWork : IDbUnitOfWork
    {
        IMongoDatabase _database;
        public UnitOfWork(IMongoDatabase database)
        {
            _database=database;
            People = new PersonRepository(database);
        }

        public IRepository<PersonEntity> People { get; private set; }

        public Task<int> SaveChangesAsync(CancellationToken ct) => Task.FromResult(1);

    }

}
