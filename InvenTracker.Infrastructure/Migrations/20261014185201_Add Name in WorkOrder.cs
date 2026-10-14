using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNameinWorkOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WorkOrders");
        }
    }
}
