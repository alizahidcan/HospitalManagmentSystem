using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagment.Data.Migrations
{
    /// <inheritdoc />
    public partial class TotalUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Appointments");

            migrationBuilder.AddColumn<DateOnly>(
                name: "justDate",
                table: "Appointments",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "time",
                table: "Appointments",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "justDate",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "time",
                table: "Appointments");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
