using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repo.Framework;

namespace Repo.SQL
{
    public class StartUp
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IRepository<PersonEntity>, PersonRepository>();

            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("_MyDb"));

        }
    }
}
