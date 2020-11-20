using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pools.Api.Data;
using Pools.Api.Services;

namespace Pools.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PoolsController : ControllerBase
    {
        private readonly IPoolRepository _poolRepository;

        public PoolsController(IPoolRepository poolRepository)
        {
            _poolRepository = poolRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pool>>> GetPools()
        {

            return Ok(await _poolRepository.GetAllPools());
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Pool>> GetPool(int id)
        // {
        //     var pool = await _context.Pool.FindAsync(id);

        //     if (pool == null)
        //     {
        //         return NotFound();
        //     }

        //     return pool;
        // }


        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutPool(int id, Pool pool)
        // {
        //     if (id != pool.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(pool).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!PoolExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // [HttpPost]
        // public async Task<ActionResult<Pool>> PostPool(Pool pool)
        // {
        //     _context.Pool.Add(pool);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetPool), new { id = pool.Id }, pool);
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Pool>> DeletePool(int id)
        // {
        //     var pool = await _context.Pool.FindAsync(id);
        //     if (pool == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Pool.Remove(pool);
        //     await _context.SaveChangesAsync();

        //     return pool;
        // }

        // private bool PoolExists(int id)
        // {
        //     return _context.Pool.Any(e => e.Id == id);
        // }
    }
}
