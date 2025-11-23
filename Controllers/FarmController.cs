using Microsoft.AspNetCore.Mvc;
using FarmApi.Services;

namespace FarmApi.Controllers
{
    [ApiController]
    [Route("/")]  // Base path
    public class FarmController : ControllerBase
    {
        private readonly FarmService _farmService;

        public FarmController(FarmService farmService)
        {
            _farmService = farmService;
        }

        // -----------------------
        // WEATHER
        // -----------------------
        [HttpGet("weatherforecast")]
        public IActionResult GetWeather()
        {
            var result = _farmService.GetWeather();
            return Ok(result);
        }

        // -----------------------
        // GET FARM ANIMALS
        // -----------------------
        [HttpGet("animals")]
        public IActionResult GetFarmAnimals()
        {
            var result = _farmService.GetFarmAnimals();
            return Ok(result);
        }

        // -----------------------
        // GET FOODS
        // -----------------------
        [HttpGet("foods")]
        public IActionResult GetFoods()
        {
            var result = _farmService.GetFoods();
            return Ok(result);
        }
    }
}
