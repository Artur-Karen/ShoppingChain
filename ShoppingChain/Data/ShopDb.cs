using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingChain.Models;

namespace ShoppingChain.Data
{
    public class ShopDb : IdentityDbContext
    {
        public ShopDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Shop> shops { get; set; }
        public DbSet<Bakery> bakeries { get; set; }
        public DbSet<Storage> storages { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
    
}
