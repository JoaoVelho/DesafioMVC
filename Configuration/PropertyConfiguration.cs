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
                        "db593cb0-0512-4f8d-ab7b-035ee76d2a63-apt1.jpg"
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
                        "82f1291f-f150-4103-b29a-c405f318606d-casa1.jpg",
                        "68ea92f8-5a06-4cc6-8e37-9d3f6f247f2a-casa2.jpg"
                    }
                },
                new Property {
                    Id = 3,
                    CategoryId = 1,
                    BusinessId = 2,
                    DistrictId = 2,
                    Address = "Rua Brasil Brazuca, nº 122",
                    Rooms = 2,
                    Images = new string[] {
                        "a33d66ba-d37f-4c84-9888-bde174cfd011-apt2.jpg",
                        "c28908e4-8847-46f1-904e-e885829cadc6-apt3.jpg",
                        "6f4e385e-ffdf-4c9c-91d4-9c0d940d505d-apt4.jpg"
                    }
                },
                new Property {
                    Id = 4,
                    CategoryId = 2,
                    BusinessId = 1,
                    DistrictId = 1,
                    Address = "Rua São João Joaquim, nº 2",
                    Rooms = 3,
                    Images = new string[] {
                        "b54b0af3-57c6-4858-a772-ed2953ed511d-casa3.jpg",
                        "594b4eff-0e47-41ca-9818-f81f53747ea2-casa4.jpg"
                    }
                }
            );
        }
    }
}