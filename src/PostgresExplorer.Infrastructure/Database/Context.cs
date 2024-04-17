using Microsoft.EntityFrameworkCore;

namespace PostgresExplorer.Infrastructure.Database
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var conn = Environment.GetEnvironmentVariable("DBCONN");

            //if (!string.IsNullOrEmpty(conn))
            //{
            //    optionsBuilder.UseNpgsql(conn);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}