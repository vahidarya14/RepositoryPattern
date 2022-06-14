using _2_DomainEntities;
using MongoDB.Driver;
using Repo.Framework;

namespace Repo.MongoDb
{
    public class PersonRepository : IRepository<PersonEntity>
    {
        protected IMongoCollection<PersonEntity> Collection;

        public PersonRepository(IMongoDatabase database) 
        {
            Collection = database.GetCollection<PersonEntity>("People");
        }



        public List<PersonEntity> GetItems()
        {
            var lst = Collection.Find(x => true);
            return  lst.ToList();
        }

        public async ValueTask<PersonEntity> InsertAsync(PersonEntity model, CancellationToken cancellationToken=default)
        {
            model.Id = Guid.NewGuid();

            await Collection.InsertOneAsync(model,cancellationToken:cancellationToken);
            return model;
        }

        public async ValueTask<PersonEntity> UpdateAsync(PersonEntity model, CancellationToken cancellationToken = default)
        {
            var res = await Collection.ReplaceOneAsync(x => x.Id == model.Id, model, cancellationToken: cancellationToken).ConfigureAwait(false);
            return model;
        }


        public  async ValueTask<bool> Remove(Guid id, CancellationToken cancellationToken)
        {
            var res = await Collection.DeleteOneAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            return res.DeletedCount>1;
        }

 
    }
}