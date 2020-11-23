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
        public async Task<IEnumerable<Pool>> GetAllPools()
        {
            return await _context.Pools.ToListAsync();
        }

        public Task<Pool> GetPoolById(int id)
        {
            return _context.Pools.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}