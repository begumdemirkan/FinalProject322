using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject322.Migrations
{
    public partial class nb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "totaloriginal",
                table: "Order",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totaloriginal",
                table: "Order");
        }
    }
}
