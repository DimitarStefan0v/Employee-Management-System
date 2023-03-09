#nullable disable

namespace EMS.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class AddPropAddByUserForEmployeesAndAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_ApplicationUserId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_ApplicationUserId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Employees",
                newName: "AddedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ApplicationUserId",
                table: "Employees",
                newName: "IX_Employees_AddedByUserId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Assignments",
                newName: "AddedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_ApplicationUserId",
                table: "Assignments",
                newName: "IX_Assignments_AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_AddedByUserId",
                table: "Assignments",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AddedByUserId",
                table: "Employees",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_AddedByUserId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AddedByUserId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "Employees",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_AddedByUserId",
                table: "Employees",
                newName: "IX_Employees_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "Assignments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_AddedByUserId",
                table: "Assignments",
                newName: "IX_Assignments_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_ApplicationUserId",
                table: "Assignments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_ApplicationUserId",
                table: "Employees",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
