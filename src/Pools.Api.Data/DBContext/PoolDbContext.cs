using Microsoft.EntityFrameworkCore;

namespace Pools.Api.Data.DBContext
{
    public class PoolDbContext : DbContext
    {
        public PoolDbContext(DbContextOptions<PoolDbContext> options): base(options)
        {
        }

        public DbSet<Pool> Pools { get; set; }
    }
}