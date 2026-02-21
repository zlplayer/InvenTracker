using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dzielenieSzuflad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawers_Wardrobes_WardrobeId",
                table: "Drawers");

            migrationBuilder.AlterColumn<Guid>(
                name: "WardrobeId",
                table: "Drawers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "AvailablePartitions",
                table: "Drawers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentDrawerId",
                table: "Drawers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPartitions",
                table: "Drawers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_ParentDrawerId",
                table: "Drawers",
                column: "ParentDrawerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drawers_Drawers_ParentDrawerId",
                table: "Drawers",
                column: "ParentDrawerId",
                principalTable: "Drawers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drawers_Wardrobes_WardrobeId",
                table: "Drawers",
                column: "WardrobeId",
                principalTable: "Wardrobes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawers_Drawers_ParentDrawerId",
                table: "Drawers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drawers_Wardrobes_WardrobeId",
                table: "Drawers");

            migrationBuilder.DropIndex(
                name: "IX_Drawers_ParentDrawerId",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "AvailablePartitions",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "ParentDrawerId",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "TotalPartitions",
                table: "Drawers");

            migrationBuilder.AlterColumn<Guid>(
                name: "WardrobeId",
                table: "Drawers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drawers_Wardrobes_WardrobeId",
                table: "Drawers",
                column: "WardrobeId",
                principalTable: "Wardrobes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
