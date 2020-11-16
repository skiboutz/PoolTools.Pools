using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PoolTools.Pools.Api
{
    [ApiController]
    [Route("[controller]")]
    public class PoolController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetPools()
        {
            return Ok(new List<string>{"pool1", "pool2"});
        }
    }
}