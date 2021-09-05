using Microsoft.EntityFrameworkCore;
using PopulationAPI.Data.Entities;

namespace PopulationAPI.Data
{
    public class PopulationDbContext : DbContext
    {
        public PopulationDbContext(DbContextOptions<PopulationDbContext> options) : base(options)
        {

        }

        public DbSet<Actual> Actuals { get; set; }

        public DbSet<Estimate> Estimates { get; set; }
    }
}
