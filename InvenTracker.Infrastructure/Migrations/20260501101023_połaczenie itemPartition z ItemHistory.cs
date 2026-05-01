using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class połaczenieitemPartitionzItemHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemPartitionId",
                table: "ItemHistories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistories_ItemPartitionId",
                table: "ItemHistories",
                column: "ItemPartitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHistories_ItemPartitions_ItemPartitionId",
                table: "ItemHistories",
                column: "ItemPartitionId",
                principalTable: "ItemPartitions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemHistories_ItemPartitions_ItemPartitionId",
                table: "ItemHistories");

            migrationBuilder.DropIndex(
                name: "IX_ItemHistories_ItemPartitionId",
                table: "ItemHistories");

            migrationBuilder.DropColumn(
                name: "ItemPartitionId",
                table: "ItemHistories");
        }
    }
}
