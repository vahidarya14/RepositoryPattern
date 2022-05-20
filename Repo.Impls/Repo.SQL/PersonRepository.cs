using Microsoft.EntityFrameworkCore;
using Repo.Framework;

namespace Repo.SQL
{
    public class PersonRepository : IRepository<PersonEntity>
    {
        AppDbContext _dbContext;

        public PersonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<PersonEntity> GetItems() => _dbContext.People.ToList();


        public async ValueTask<PersonEntity> InsertAsync(PersonEntity p, CancellationToken cancellationToken)
        {
            p.Id = Guid.NewGuid();
            await _dbContext.People.AddAsync(p, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return p;
        }

        public async ValueTask<PersonEntity> UpdateAsync(PersonEntity model, CancellationToken cancellationToken)
        {
            var p = await _dbContext.People.FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);

            p.FirstName = model.FirstName;
            p.LastName = model.LastName;
            _dbContext.People.Update(p);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return p;
        }

        public async ValueTask<bool> Remove(Guid id, CancellationToken cancellationToken)
        {
            var p = await _dbContext.People.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            _dbContext.People.Remove(p);
            var res = await _dbContext.SaveChangesAsync(cancellationToken);

            return res > 1;
        }


    }
}
