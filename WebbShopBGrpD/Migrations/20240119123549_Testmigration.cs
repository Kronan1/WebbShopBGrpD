using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebbShopBGrpD.Migrations
{
    /// <inheritdoc />
    public partial class Testmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedArticles_Orders_OrderId",
                table: "PurchasedArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedArticles_Products_ProductId",
                table: "PurchasedArticles");

            migrationBuilder.DropIndex(
                name: "IX_PurchasedArticles_ProductId",
                table: "PurchasedArticles");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "PurchasedArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedArticles_Orders_OrderId",
                table: "PurchasedArticles",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedArticles_Orders_OrderId",
                table: "PurchasedArticles");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "PurchasedArticles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedArticles_ProductId",
                table: "PurchasedArticles",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedArticles_Orders_OrderId",
                table: "PurchasedArticles",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedArticles_Products_ProductId",
                table: "PurchasedArticles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
