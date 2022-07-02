using Elasticsearch.Net;
using Nest;
using Microsoft.Extensions.DependencyInjection;
using _2_DomainEntities;
using _4_UnitOfWork;

namespace Repo.Elastic
{
    public class StartUp
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbUnitOfWork, UnitOfWork>();
            services.AddScoped<Framework.IRepository<PersonEntity>, PersonRepository>();

            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);
            services.AddSingleton(client);

        }
    }
}
