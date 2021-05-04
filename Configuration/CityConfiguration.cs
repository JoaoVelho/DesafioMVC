using DesafioMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                new City {
                    Id = 1,
                    Name = "Bauru",
                    StateId = 1
                },
                new City {
                    Id = 2,
                    Name = "Curitiba",
                    StateId = 2
                }
            );
        }
    }
}