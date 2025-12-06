using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCareAppApi.Migrations
{
    /// <inheritdoc />
    public partial class removeAndUdpatedColumandName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_company_locationId",
                table: "ApplicationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_role_RoleId",
                table: "ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_locationId",
                table: "Users",
                newName: "IX_Users_locationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_company_locationId",
                table: "Users",
                column: "locationId",
                principalTable: "company",
                principalColumn: "Id",
               onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_company_locationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_role_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_locationId",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_locationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_company_locationId",
                table: "ApplicationUser",
                column: "locationId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_role_RoleId",
                table: "ApplicationUser",
                column: "RoleId",
                principalTable: "role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
