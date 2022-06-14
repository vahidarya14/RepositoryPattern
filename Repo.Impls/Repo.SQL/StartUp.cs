using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repo.Framework;
using _2_DomainEntities;
using _4_UnitOfWork;

namespace Repo.SQL
{
    public class StartUp
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<PersonEntity>, PersonRepository>();

            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("_MyDb"));

        }
    }
}
