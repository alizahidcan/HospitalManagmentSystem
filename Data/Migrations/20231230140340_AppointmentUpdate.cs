using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagment.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_userId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_userId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Appointments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userName",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_userId",
                table: "Appointments",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_userId",
                table: "Appointments",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
