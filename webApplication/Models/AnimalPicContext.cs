using Microsoft.EntityFrameworkCore;
namespace webApplication.Models
{
        public class AnimalPicContext : DbContext
        {
            public AnimalPicContext(DbContextOptions<AnimalPicContext> options) : base(options)
            {

            }
            public DbSet<AnimalPic> AnimalPic { get; set; }
        }
    
}
