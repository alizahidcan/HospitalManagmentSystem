using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagment.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "workinghours",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Doctors",
                table: "Departments",
                newName: "DoctorsName");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors",
                column: "departmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DoctorsName",
                table: "Departments",
                newName: "Doctors");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "workinghours",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_departmentId",
                table: "Doctors",
                column: "departmentId");
        }
    }
}
