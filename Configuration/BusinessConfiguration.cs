using DesafioMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasData(
                new Business {
                    Id = 1,
                    Name = "Aluguel"
                },
                new Business {
                    Id = 2,
                    Name = "Venda"
                }
            );
        }
    }
}