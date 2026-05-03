using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Dodanierelacjidoszaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WardrobeId",
                table: "WorkOrders",
                column: "WardrobeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Wardrobes_WardrobeId",
                table: "WorkOrders",
                column: "WardrobeId",
                principalTable: "Wardrobes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Wardrobes_WardrobeId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_WardrobeId",
                table: "WorkOrders");
        }
    }
}
