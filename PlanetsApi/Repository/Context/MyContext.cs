using Microsoft.EntityFrameworkCore;
using PlanetsApi.Models;

namespace PlanetsApi.Repository.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options) { }

        public DbSet<Planet> Planets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Planet>()
                .Ignore(p => p.ApparitionsInFilms);
        }
    }
}
