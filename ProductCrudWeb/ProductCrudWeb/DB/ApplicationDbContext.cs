using Microsoft.EntityFrameworkCore;
using ProductCrudWeb.Models;

namespace ProductCrudWeb.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
