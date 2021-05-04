using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMVC.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(
                new IdentityUser {
                    Id = "757d9d6d-7c65-4cb1-ac67-0657fa39a5ae",
                    UserName = "adm@admin.com",
                    NormalizedUserName = "ADM@ADMIN.COM",
                    Email = "adm@admin.com",
                    NormalizedEmail = "ADM@ADMIN.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEJ6L4f9lICMkvOXKImNvA11SZYp71BADBRhc+HqqPIQVZvJIkOfbr4Q43zDRhlhybQ==",
                    SecurityStamp = "6BONVWXGHP4QNSWEM43XK2CWA6G62ZPH",
                    ConcurrencyStamp = "fee3156f-876e-4df1-b122-ca2d59df4fdb",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            );
        }
    }
}