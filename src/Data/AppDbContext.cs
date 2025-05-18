using Microsoft.EntityFrameworkCore;
using webapi_agende_mais.src.Models;

namespace webapi_agende_mais.src.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
