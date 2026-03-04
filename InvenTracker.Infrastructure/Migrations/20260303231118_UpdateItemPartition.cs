using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemPartition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPartition_Items_ItemId",
                table: "ItemPartition");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPartition_Partitions_PartitionId",
                table: "ItemPartition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPartition",
                table: "ItemPartition");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "ItemPartition",
                newName: "ItemPartitions");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPartition_PartitionId",
                table: "ItemPartitions",
                newName: "IX_ItemPartitions_PartitionId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPartition_ItemId",
                table: "ItemPartitions",
                newName: "IX_ItemPartitions_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "QuantityItem",
                table: "ItemPartitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPartitions",
                table: "ItemPartitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPartitions_Items_ItemId",
                table: "ItemPartitions",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPartitions_Partitions_PartitionId",
                table: "ItemPartitions",
                column: "PartitionId",
                principalTable: "Partitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPartitions_Items_ItemId",
                table: "ItemPartitions");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemPartitions_Partitions_PartitionId",
                table: "ItemPartitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPartitions",
                table: "ItemPartitions");

            migrationBuilder.DropColumn(
                name: "QuantityItem",
                table: "ItemPartitions");

            migrationBuilder.RenameTable(
                name: "ItemPartitions",
                newName: "ItemPartition");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPartitions_PartitionId",
                table: "ItemPartition",
                newName: "IX_ItemPartition_PartitionId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPartitions_ItemId",
                table: "ItemPartition",
                newName: "IX_ItemPartition_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPartition",
                table: "ItemPartition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPartition_Items_ItemId",
                table: "ItemPartition",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPartition_Partitions_PartitionId",
                table: "ItemPartition",
                column: "PartitionId",
                principalTable: "Partitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
