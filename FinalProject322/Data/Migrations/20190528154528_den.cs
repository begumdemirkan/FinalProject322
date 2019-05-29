using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject322.Data.Migrations
{
    public partial class den : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ShoppingCarts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ShoppingCarts",
                newName: "UserrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserrId",
                table: "ShoppingCarts",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingCarts",
                newName: "CategoryId");
        }
    }
}
