using Microsoft.EntityFrameworkCore;

namespace Pools.Api.Data.DBContext
{
    public class TradeDbContext : DbContext
    {
        public DbSet<Trade> Trades { get; set; }

        public TradeDbContext(DbContextOptions<TradeDbContext> options): base(options)
        {            
        }
    }
}