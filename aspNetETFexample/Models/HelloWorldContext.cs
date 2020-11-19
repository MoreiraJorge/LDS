using Microsoft.EntityFrameworkCore;

namespace aspNetETFexample.Models
{
    public class HelloWorldContext : DbContext
    {
        public HelloWorldContext(DbContextOptions<HelloWorldContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
