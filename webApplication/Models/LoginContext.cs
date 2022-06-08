using Microsoft.EntityFrameworkCore;
namespace webApplication.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {

        }
        public DbSet<Login> Logins { get; set; }
    }
}
