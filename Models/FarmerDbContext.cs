using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
    public class FarmerDbContext : DbContext
    {
        public FarmerDbContext(DbContextOptions<FarmerDbContext> options) : base(options)
        {

        }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Farm> Farms { get; set; }

        
    }
}
