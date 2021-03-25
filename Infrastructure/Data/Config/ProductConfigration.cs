using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m=>m.Id);
            builder.Property(m=>m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m=>m.Price).IsRequired().HasColumnType("decimal(20,2)");
            builder.Property(m=>m.Description).HasMaxLength(150).IsRequired();
            builder.Property(m=>m.PictureUrl).IsRequired();
            builder.HasOne(m=>m.ProductBrand).WithMany().HasForeignKey(m=>m.ProductBrandId);
            builder.HasOne(m=>m.ProductType).WithMany().HasForeignKey(m=>m.ProductBrandId);
            
        }
    }
}