using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCCore_2.Models;

namespace MVCCore_2.Models.Configurations.Categories
{
    public class Category_CNF : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.HasData(
                    new Category(){ CategoryId = 1, Name = "Kırtasiye" },
                    new Category(){ CategoryId = 2, Name = "Hediyelik" },
                    new Category(){ CategoryId = 3, Name = "Giyim" },
                    new Category(){ CategoryId = 4, Name = "Ayakkabı" }
                    );
        }
    }
}
