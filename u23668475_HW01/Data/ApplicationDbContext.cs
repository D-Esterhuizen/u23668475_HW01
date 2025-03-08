using Microsoft.EntityFrameworkCore;
using u23668475_HW01.Models;

namespace u23668475_HW01.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

       

    }
}
