using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LengthPartition",
                table: "Partitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LengthDrawer",
                table: "Drawers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LengthPartition",
                table: "Partitions");

            migrationBuilder.DropColumn(
                name: "LengthDrawer",
                table: "Drawers");
        }
    }
}
