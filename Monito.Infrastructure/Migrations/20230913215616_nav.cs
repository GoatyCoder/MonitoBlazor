using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monito.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varieties_Products_ProductId",
                table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Varieties_ProductId",
                table: "Varieties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Varieties_ProductId",
                table: "Varieties",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Varieties_Products_ProductId",
                table: "Varieties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
