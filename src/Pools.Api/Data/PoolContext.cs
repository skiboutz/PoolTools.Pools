using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pools.Api.Data;

    public class PoolContext : DbContext
    {
        public PoolContext (DbContextOptions<PoolContext> options)
            : base(options)
        {
        }

        public DbSet<Pools.Api.Data.Pool> Pool { get; set; }
    }
