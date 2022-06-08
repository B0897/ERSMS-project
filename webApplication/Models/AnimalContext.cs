using Microsoft.EntityFrameworkCore;
namespace webApplication.Models
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options) 
        { 
        
        }
        public DbSet<Animal> Animal { get; set; }
    }
}
