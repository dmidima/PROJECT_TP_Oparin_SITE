using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITE.Data.Migrations
{
    public partial class NewtableBookingEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "kyda",
                schema: "data",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "otkyda",
                schema: "data",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "kyda", "otkyda" },
                values: new object[] { "Иваново", "Владимир" });

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 28, 20, 45, 59, 46, DateTimeKind.Local).AddTicks(2841));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kyda",
                schema: "data",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "otkyda",
                schema: "data",
                table: "Bookings");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 28, 18, 8, 6, 367, DateTimeKind.Local).AddTicks(7571));
        }
    }
}
