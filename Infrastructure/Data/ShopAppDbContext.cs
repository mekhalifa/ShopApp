
using System.Reflection;
using Core.Entities;
using Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShopAppDbContext : DbContext
    {
        public ShopAppDbContext( DbContextOptions<ShopAppDbContext> options)
         : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}