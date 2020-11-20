using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pools.Api.Data;

    public class TradeContext : DbContext
    {
        public TradeContext (DbContextOptions<TradeContext> options)
            : base(options)
        {
        }

        public DbSet<Pools.Api.Data.Trade> Trade { get; set; }
    }
