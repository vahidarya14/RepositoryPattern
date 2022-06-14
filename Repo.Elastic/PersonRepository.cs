using _2_DomainEntities;
using Nest;
using Repo.Framework;

namespace Repo.Elastic
{
    public class PersonRepository : Framework.IRepository<PersonEntity>
    {
        private readonly ElasticClient _client;

        public PersonRepository(ElasticClient client)
        {
            _client = client;
        }


        public List<PersonEntity> GetItems()
        {
            ISearchResponse<PersonEntity> results;
            results = _client.Search<PersonEntity>(s => s
                    .Query(q => q.MatchAll())
                //  .Aggregations(a => a.Range("pageCounts", r => r
                //                    .Field(f => f.PageCount)
                //                    .Ranges(r => r.From(0),
                //                            r => r.From(200).To(400),
                //                            r => r.From(400)))
                //                    .Terms("categories", t => t.Field("categories.keyword"))
                //  )
                );

            return results.Documents.ToList();
        }

        public async ValueTask<PersonEntity> InsertAsync(PersonEntity model, CancellationToken cancellationToken = default)
        {
            //var asyncBulkIndexResponse = await _client.BulkAsync(b => b
            //                                  .Index("PersonEntity").IndexMany(new[]{model }));
            var indexResponseAsync = await _client.IndexDocumentAsync(model, cancellationToken);
            if (!indexResponseAsync.IsValid)
            {
            }

            return model;
        }

        public async ValueTask<bool> Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var indexResponseAsync = await _client.DeleteAsync<PersonEntity>(id, ct: cancellationToken);
            return indexResponseAsync.IsValid;
        }

        public async ValueTask<PersonEntity> UpdateAsync(PersonEntity model, CancellationToken cancellationToken = default)
        {
            var response = await _client.UpdateAsync<PersonEntity>(model.Id, u => u.Index("PersonEntity").Doc(model), cancellationToken);

            return model;
        }
    }
}