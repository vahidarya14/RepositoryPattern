using Microsoft.EntityFrameworkCore;
using Repo.Framework;

namespace Repo.SQL
{
    public class AppDbContext : DbContext
    {
        public DbSet<PersonEntity> People { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonEntity>(b =>
            {
                b.HasKey(a => a.Id);
            });


        }


    }



}