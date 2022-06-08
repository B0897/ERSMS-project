using Microsoft.EntityFrameworkCore;
namespace webApplication.Models
{
    public class UserAnimalFrontContext : DbContext
    {
        public UserAnimalFrontContext(DbContextOptions<UserAnimalFrontContext> options) : base(options)
        {

        }
        public DbSet<LikedFront> UserAnimals { get; set; }
    }
}