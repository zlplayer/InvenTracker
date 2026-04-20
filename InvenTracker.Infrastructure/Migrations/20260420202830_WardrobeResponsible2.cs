using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WardrobeResponsible2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WardrobesResponsibles",
                table: "WardrobesResponsibles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WardrobesResponsibles",
                table: "WardrobesResponsibles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WardrobesResponsibles_WardrobeId",
                table: "WardrobesResponsibles",
                column: "WardrobeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WardrobesResponsibles",
                table: "WardrobesResponsibles");

            migrationBuilder.DropIndex(
                name: "IX_WardrobesResponsibles_WardrobeId",
                table: "WardrobesResponsibles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WardrobesResponsibles",
                table: "WardrobesResponsibles",
                columns: new[] { "WardrobeId", "UserId" });
        }
    }
}
