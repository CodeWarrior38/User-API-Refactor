using Microsoft.EntityFrameworkCore;

namespace Tests.User.Api
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Models.User> Users { get; set; }
    }
}
