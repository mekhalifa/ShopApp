
using Core.Entities;
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
    }
}