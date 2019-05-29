using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject322.Data.Migrations
{
    public partial class sepet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "UserrId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserrId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "Id");
        }
    }
}
