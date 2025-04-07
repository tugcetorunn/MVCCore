using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCore_2.Models;

namespace MVCCore_2.Models.Configurations.Products
{
    public class Product_CNF : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Price).IsRequired().HasColumnType("money");
            builder.Property(p => p.Description).HasMaxLength(200);
            builder.Property(p => p.ImageUrl).HasMaxLength(100).HasColumnType("varchar");
        }
    }
}
