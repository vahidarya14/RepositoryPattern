using _2_DomainEntities;
using _4_UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Repo.Framework;

namespace Repo.MongoDb
{
    public class StartUp
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<PersonEntity>, PersonRepository>();

            services.AddSingleton(x =>
                {
                    var client = new MongoClient("mongodb://localhost:27017");
                    var database = client.GetDatabase("_MyDb");
                    return database;
                });

        }

    }
}