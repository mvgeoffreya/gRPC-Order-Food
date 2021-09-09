using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;

        public FoodController(ILogger<FoodController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        
        public async Task<Array> Get()
        {
            return await Food.getFood("Geoffrey");
        }
    }
}
