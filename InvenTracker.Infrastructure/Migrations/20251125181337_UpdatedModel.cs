using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvenTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCompany_Companies_CompanyId",
                table: "AddressCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDepartment_Departments_DepartmentId",
                table: "AddressDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressDepartment",
                table: "AddressDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressCompany",
                table: "AddressCompany");

            migrationBuilder.RenameTable(
                name: "AddressDepartment",
                newName: "AddressDepartments");

            migrationBuilder.RenameTable(
                name: "AddressCompany",
                newName: "AddressCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_AddressDepartment_DepartmentId",
                table: "AddressDepartments",
                newName: "IX_AddressDepartments_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressCompany_CompanyId",
                table: "AddressCompanies",
                newName: "IX_AddressCompanies_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressDepartments",
                table: "AddressDepartments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressCompanies",
                table: "AddressCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCompanies_Companies_CompanyId",
                table: "AddressCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDepartments_Departments_DepartmentId",
                table: "AddressDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCompanies_Companies_CompanyId",
                table: "AddressCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDepartments_Departments_DepartmentId",
                table: "AddressDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressDepartments",
                table: "AddressDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressCompanies",
                table: "AddressCompanies");

            migrationBuilder.RenameTable(
                name: "AddressDepartments",
                newName: "AddressDepartment");

            migrationBuilder.RenameTable(
                name: "AddressCompanies",
                newName: "AddressCompany");

            migrationBuilder.RenameIndex(
                name: "IX_AddressDepartments_DepartmentId",
                table: "AddressDepartment",
                newName: "IX_AddressDepartment_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressCompanies_CompanyId",
                table: "AddressCompany",
                newName: "IX_AddressCompany_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressDepartment",
                table: "AddressDepartment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressCompany",
                table: "AddressCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCompany_Companies_CompanyId",
                table: "AddressCompany",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDepartment_Departments_DepartmentId",
                table: "AddressDepartment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
