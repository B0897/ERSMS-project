using Microsoft.EntityFrameworkCore;
namespace webApplication.Models
{
    public class LikedContext : DbContext
    {
        public LikedContext(DbContextOptions<LikedContext> options) : base(options)
        {

        }
        public DbSet<Liked> Liked { get; set; }
    }
}
