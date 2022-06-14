using _2_DomainEntities;
using _4_UnitOfWork;
using Repo.Framework;

namespace Repo.SQL
{
   

    public class UnitOfWork : IDbUnitOfWork
    {
        AppDbContext _database;
        public UnitOfWork(AppDbContext database)
        {
            _database=database;
            People = new PersonRepository(database);
        }

        public IRepository<PersonEntity> People { get; private set; }

        public Task<int> SavechangesAsync() => _database.SaveChangesAsync();

    }

}
