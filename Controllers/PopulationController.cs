using Microsoft.AspNetCore.Mvc;
using PopulationAPI.Services;
using Serilog;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly IPopulationService _populationService;

        public PopulationController(IPopulationService populationService)
        {
            _populationService = populationService;
        }

        /// <summary>
        /// Retrieves population by state, state must be comma separated numbers
        /// </summary>
        /// <param name="state" example="1,10,12">The product id</param>
        [HttpGet]
        public async Task<IActionResult> Get([Required] string state)
        {
            Log.Information($"{DateTime.Now.ToString("yyyy-mm-dd hh24:mi:ss.fff", CultureInfo.InvariantCulture)} - API endpoint called - /population?state={state}");

            var statesInt = state.Split(',').Select(int.Parse).ToArray();

            var result = await _populationService.GetByState(statesInt);

            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
