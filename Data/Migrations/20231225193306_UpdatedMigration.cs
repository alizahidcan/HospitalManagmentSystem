using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagment.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DoctorsName",
                table: "Departments",
                newName: "role");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "holidayDay",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "workingHours",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors",
                column: "departmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "holidayDay",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "workingHours",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Departments",
                newName: "DoctorsName");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors",
                column: "departmentId",
                unique: true);
        }
    }
}
