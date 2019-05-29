using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject322.Data.Migrations
{
    public partial class asnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_OrderDetailsCard_OrderDetailsCardsayi",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsCardsayi",
                table: "ShoppingCart",
                newName: "OrderDetailsCardId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_OrderDetailsCardsayi",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_OrderDetailsCardId");

            migrationBuilder.RenameColumn(
                name: "sayi",
                table: "OrderDetailsCard",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_OrderDetailsCard_OrderDetailsCardId",
                table: "ShoppingCart",
                column: "OrderDetailsCardId",
                principalTable: "OrderDetailsCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_OrderDetailsCard_OrderDetailsCardId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsCardId",
                table: "ShoppingCart",
                newName: "OrderDetailsCardsayi");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_OrderDetailsCardId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_OrderDetailsCardsayi");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetailsCard",
                newName: "sayi");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_OrderDetailsCard_OrderDetailsCardsayi",
                table: "ShoppingCart",
                column: "OrderDetailsCardsayi",
                principalTable: "OrderDetailsCard",
                principalColumn: "sayi",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
