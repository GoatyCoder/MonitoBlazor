using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monito.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedane_Articles_ArticleId",
                table: "Pedane");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedane_Products_ProductId",
                table: "Pedane");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedane_Varieties_VarietyId",
                table: "Pedane");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedane_secondaryPackagings_SecondaryPackagingId",
                table: "Pedane");

            migrationBuilder.DropIndex(
                name: "IX_Pedane_ArticleId",
                table: "Pedane");

            migrationBuilder.DropIndex(
                name: "IX_Pedane_ProductId",
                table: "Pedane");

            migrationBuilder.DropIndex(
                name: "IX_Pedane_SecondaryPackagingId",
                table: "Pedane");

            migrationBuilder.DropIndex(
                name: "IX_Pedane_VarietyId",
                table: "Pedane");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedane_ArticleId",
                table: "Pedane",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedane_ProductId",
                table: "Pedane",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedane_SecondaryPackagingId",
                table: "Pedane",
                column: "SecondaryPackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedane_VarietyId",
                table: "Pedane",
                column: "VarietyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedane_Articles_ArticleId",
                table: "Pedane",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedane_Products_ProductId",
                table: "Pedane",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedane_Varieties_VarietyId",
                table: "Pedane",
                column: "VarietyId",
                principalTable: "Varieties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedane_secondaryPackagings_SecondaryPackagingId",
                table: "Pedane",
                column: "SecondaryPackagingId",
                principalTable: "secondaryPackagings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
