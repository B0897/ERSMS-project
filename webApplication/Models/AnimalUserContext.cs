using Microsoft.EntityFrameworkCore;
namespace webApplication.Models
{
    public class AnimalUserContext : DbContext
    {
        public AnimalUserContext(DbContextOptions<AnimalUserContext> options) : base(options)
        {

        }
        public DbSet<AnimalUser> AnimalUser { get; set; }
    }
}
