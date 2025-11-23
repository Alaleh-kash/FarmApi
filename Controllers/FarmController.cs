using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmApi.Data;

namespace FarmApi.Controllers
{
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly FarmDbContext _db;

        public FarmController(FarmDbContext db)
        {
            _db = db;
        }

        // GET /animals
        [HttpGet("animals")]
        public async Task<IActionResult> GetAnimals()
        {
            return Ok(await _db.Animals.ToListAsync());
        }

        // GET /foods
        [HttpGet("foods")]
        public async Task<IActionResult> GetFoods()
        {
            return Ok(await _db.Foods.ToListAsync());
        }

        // GET /weather  (STATIC for now)
        [HttpGet("weather")]
        public IActionResult GetWeather()
        {
            return Ok(new { temp = 22, condition = "Sunny" });
        }
    }
}
