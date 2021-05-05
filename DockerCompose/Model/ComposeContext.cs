using Microsoft.EntityFrameworkCore;

namespace DockerCompose.Model
{
    public class ComposeContext : DbContext
    {
        public ComposeContext(DbContextOptions<ComposeContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get; set;}
    }
}