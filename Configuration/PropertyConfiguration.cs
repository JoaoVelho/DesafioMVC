using DesafioMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasData(
                new Property {
                    Id = 1,
                    CategoryId = 1,
                    BusinessId = 1,
                    DistrictId = 1,
                    Address = "Av Jorge Jorgin, nº 123",
                    Rooms = 4,
                    Images = new string[] {
                        "a318311d-b217-410b-becb-8a3e35ee92c8-download.jpg", 
                        "651d8799-5abe-4716-a7dc-979b43c8f575-MicrosoftTeams-image.png"
                    }
                },
                new Property {
                    Id = 2,
                    CategoryId = 2,
                    BusinessId = 2,
                    DistrictId = 2,
                    Address = "Rua Joaquim Verdura, nº 444",
                    Rooms = 2,
                    Images = new string[] {
                        "9577a4e7-9918-42d3-a5b4-26035780b056-home3.jpg"
                    }
                }
            );
        }
    }
}