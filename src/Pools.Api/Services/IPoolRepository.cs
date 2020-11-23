using System.Collections.Generic;
using System.Threading.Tasks;
using Pools.Api.Data;

namespace Pools.Api.Services
{
    public interface IPoolRepository
    {
        Task<IEnumerable<Pool>> GetAllPools();
        Task<Pool> GetPoolById(int id);
    }
}