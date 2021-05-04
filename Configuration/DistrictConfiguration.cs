using DesafioMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasData(
                new District {
                    Id = 1,
                    Name = "Centro",
                    CityId = 1
                },
                new District {
                    Id = 2,
                    Name = "Água Verde",
                    CityId = 2
                }
            );
        }
    }
}