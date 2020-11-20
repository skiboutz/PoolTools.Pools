using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pools.Api.Data;
using Pools.Api.Data.DBContext;

namespace Pools.Api.Services
{
    public class PoolRepository : IPoolRepository
    {
        private readonly PoolDbContext _context;

        public PoolRepository(PoolDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pool>> GetAllPools()
        {
            return await _context.Pools.ToListAsync();
        }
    }
}