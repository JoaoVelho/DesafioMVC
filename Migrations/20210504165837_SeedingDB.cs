using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioMVC.Migrations
{
    public partial class SeedingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "757d9d6d-7c65-4cb1-ac67-0657fa39a5ae", 0, "fee3156f-876e-4df1-b122-ca2d59df4fdb", "adm@admin.com", false, true, null, "ADM@ADMIN.COM", "ADM@ADMIN.COM", "AQAAAAEAACcQAAAAEJ6L4f9lICMkvOXKImNvA11SZYp71BADBRhc+HqqPIQVZvJIkOfbr4Q43zDRhlhybQ==", null, false, "6BONVWXGHP4QNSWEM43XK2CWA6G62ZPH", false, "adm@admin.com" });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aluguel" },
                    { 2, "Venda" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apartamento" },
                    { 2, "Casa" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name", "Uf" },
                values: new object[,]
                {
                    { 1, "São Paulo", "SP" },
                    { 2, "Paraná", "PR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Cargo", "Admin", "757d9d6d-7c65-4cb1-ac67-0657fa39a5ae" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 2, "Curitiba", 2 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[] { 1, "Bauru", 1 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 1, 1, "Centro" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 2, 2, "Água Verde" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "BusinessId", "CategoryId", "DistrictId", "Rooms", "Images" },
                values: new object[] { 1, "Av Jorge Jorgin, nº 123", 1, 1, 1, 4, "a318311d-b217-410b-becb-8a3e35ee92c8-download.jpg;651d8799-5abe-4716-a7dc-979b43c8f575-MicrosoftTeams-image.png" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "BusinessId", "CategoryId", "DistrictId", "Rooms", "Images" },
                values: new object[] { 2, "Rua Joaquim Verdura, nº 444", 2, 2, 2, 2, "9577a4e7-9918-42d3-a5b4-26035780b056-home3.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757d9d6d-7c65-4cb1-ac67-0657fa39a5ae");

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
