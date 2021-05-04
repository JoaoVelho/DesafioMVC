using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class AdminClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.HasData(
                new IdentityUserClaim<string> {
                    Id = 1,
                    UserId = "757d9d6d-7c65-4cb1-ac67-0657fa39a5ae",
                    ClaimType = "Cargo",
                    ClaimValue = "Admin"
                }
            );
        }
    }
}