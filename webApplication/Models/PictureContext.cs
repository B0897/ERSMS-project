using Microsoft.EntityFrameworkCore;
namespace webApplication.Models
{
    public class PictureContext : DbContext
    {
        public PictureContext(DbContextOptions<PictureContext> options) : base(options)
        {

        }
        public DbSet<Picture> Pictures { get; set; }
    }
}
