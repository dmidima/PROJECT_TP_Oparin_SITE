using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITE.Data.Migrations
{
    public partial class NewtableBookingTicets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ema",
                schema: "data",
                table: "Bookings",
                newName: "TimeBook");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBook",
                schema: "data",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "data",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateBook", "Email", "TimeBook" },
                values: new object[] { new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "oparins@gamil.com", "14:00" });

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 25, 23, 43, 41, 574, DateTimeKind.Local).AddTicks(5047));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBook",
                schema: "data",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "data",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TimeBook",
                schema: "data",
                table: "Bookings",
                newName: "Ema");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ema",
                value: "opari@gamil.com");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 25, 23, 4, 38, 187, DateTimeKind.Local).AddTicks(1440));
        }
    }
}
