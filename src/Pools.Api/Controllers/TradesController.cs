using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pools.Api.Data;

namespace Pools.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        private readonly TradeContext _context;

        public TradesController(TradeContext context)
        {
            _context = context;
        }

        // GET: api/Trades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trade>>> GetTrade()
        {
            return await _context.Trade.ToListAsync();
        }

        // GET: api/Trades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trade>> GetTrade(int id)
        {
            var trade = await _context.Trade.FindAsync(id);

            if (trade == null)
            {
                return NotFound();
            }

            return trade;
        }

        // PUT: api/Trades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrade(int id, Trade trade)
        {
            if (id != trade.Id)
            {
                return BadRequest();
            }

            _context.Entry(trade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Trade>> PostTrade(Trade trade)
        {
            _context.Trade.Add(trade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrade", new { id = trade.Id }, trade);
        }

        // DELETE: api/Trades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trade>> DeleteTrade(int id)
        {
            var trade = await _context.Trade.FindAsync(id);
            if (trade == null)
            {
                return NotFound();
            }

            _context.Trade.Remove(trade);
            await _context.SaveChangesAsync();

            return trade;
        }

        private bool TradeExists(int id)
        {
            return _context.Trade.Any(e => e.Id == id);
        }
    }
}
