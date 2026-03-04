using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorRelationItemPartition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Partitions_PartitionId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PartitionId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PartitionId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemPartition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPartition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPartition_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPartition_Partitions_PartitionId",
                        column: x => x.PartitionId,
                        principalTable: "Partitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPartition_ItemId",
                table: "ItemPartition",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPartition_PartitionId",
                table: "ItemPartition",
                column: "PartitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPartition");

            migrationBuilder.AddColumn<Guid>(
                name: "PartitionId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_PartitionId",
                table: "Items",
                column: "PartitionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Partitions_PartitionId",
                table: "Items",
                column: "PartitionId",
                principalTable: "Partitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
