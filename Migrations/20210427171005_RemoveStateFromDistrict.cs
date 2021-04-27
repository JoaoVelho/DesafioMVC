using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioMVC.Migrations
{
    public partial class RemoveStateFromDistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_States_StateId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Districts_StateId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Districts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Districts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_StateId",
                table: "Districts",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_States_StateId",
                table: "Districts",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
