using Microsoft.EntityFrameworkCore;
using WebAPI_Project.Data;

namespace WebAPI_Project.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.User_ID);
            modelBuilder.Entity<Order>().HasMany(o => o.Products);
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.Category_ID);
            modelBuilder.Entity<Order>().HasOne(o=>o.User);
            modelBuilder.LoadData();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
