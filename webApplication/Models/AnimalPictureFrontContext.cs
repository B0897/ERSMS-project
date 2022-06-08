using Microsoft.EntityFrameworkCore;

namespace webApplication.Models
{
    public class AnimalPictureFrontContext : DbContext
    {
        public AnimalPictureFrontContext(DbContextOptions<AnimalPictureFrontContext> options) : base(options)
        {

        }
        public DbSet<AnimalPictureFront> AnimalPictureFront { get; set; }
    }
}
