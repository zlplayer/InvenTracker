using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Partitions",
                newName: "WidthPartition");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Partitions",
                newName: "HeightPartition");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Drawers",
                newName: "WidthDrawer");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Drawers",
                newName: "HeightDrawer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WidthPartition",
                table: "Partitions",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "HeightPartition",
                table: "Partitions",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "WidthDrawer",
                table: "Drawers",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "HeightDrawer",
                table: "Drawers",
                newName: "Height");
        }
    }
}
