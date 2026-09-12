using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DodatniekolumnyIsOnlinedoszafy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Wardrobes",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Wardrobes");
        }
    }
}
