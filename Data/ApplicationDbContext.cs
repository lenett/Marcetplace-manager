using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MM.Areas.Identity.Models;
using MM.Areas.Goods.Models;

namespace MM.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Companies> Companies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}