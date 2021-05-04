using DesafioMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData(
                new State {
                    Id = 1,
                    Uf = "SP",
                    Name = "São Paulo"
                },
                new State {
                    Id = 2,
                    Uf = "PR",
                    Name = "Paraná"
                }
            );
        }
    }
}