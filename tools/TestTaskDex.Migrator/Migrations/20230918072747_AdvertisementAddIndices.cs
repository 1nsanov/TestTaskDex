using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskDex.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AdvertisementAddIndices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_ExpireDate",
                table: "Advertisements",
                column: "ExpireDate");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_Rate",
                table: "Advertisements",
                column: "Rate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Advertisement_ExpireDate",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_Rate",
                table: "Advertisements");
        }
    }
}
