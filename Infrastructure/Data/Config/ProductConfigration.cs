using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(120);
            builder.Property(m=>m.Price).IsRequired().HasColumnType("decimal(20,2)");
            builder.Property(m=>m.Description).HasMaxLength(185).IsRequired();
            builder.Property(m=>m.PictureUrl).IsRequired();
            // builder.HasOne(m=>m.ProductBrand).WithMany().HasForeignKey(m=>m.ProductBrandId).OnDelete(DeleteBehavior.Cascade);
           // builder.HasOne(m=>m.ProductType).WithMany().HasForeignKey(m=>m.ProductBrandId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}