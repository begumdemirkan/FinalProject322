using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject322.Data.Migrations
{
    public partial class ner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserrId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserrId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
