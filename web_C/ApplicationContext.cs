using Microsoft.EntityFrameworkCore;
using web_C.Models;

namespace web_C
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=initium;Username=postgres;Password=rootroot");
        }
    }
}
