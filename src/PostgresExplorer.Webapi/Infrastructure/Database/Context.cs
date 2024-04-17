using Microsoft.EntityFrameworkCore;

namespace PostgresExplorer.Webapi.Infrastructure.Database
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = Environment.GetEnvironmentVariable("DBCONN");

            if (conn != null)
            {
                optionsBuilder.UseNpgsql(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
