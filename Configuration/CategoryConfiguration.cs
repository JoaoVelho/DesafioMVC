using DesafioMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category {
                    Id = 1,
                    Name = "Apartamento"
                },
                new Category {
                    Id = 2,
                    Name = "Casa"
                }
            );
        }
    }
}