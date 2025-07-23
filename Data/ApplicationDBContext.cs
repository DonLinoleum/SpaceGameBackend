using Microsoft.EntityFrameworkCore;
using SpaceGameBackend.Models;

namespace SpaceGameBackend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<ScoreModel> Scores { get; set; } = null!;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*    var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.jsob")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
