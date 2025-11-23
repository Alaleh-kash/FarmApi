using Microsoft.EntityFrameworkCore;
using FarmApi.Models;

namespace FarmApi.Data
{
    public class FarmDbContext : DbContext
    {
        public FarmDbContext(DbContextOptions<FarmDbContext> options)
            : base(options) {}

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
