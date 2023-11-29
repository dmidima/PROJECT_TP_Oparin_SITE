using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITE.Data.Migrations
{
    public partial class NewtableReservedSeatEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataTimeRoute",
                schema: "data",
                table: "ReservedSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "ReservedSeats",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataTimeRoute",
                value: "9:00");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 28, 18, 8, 6, 367, DateTimeKind.Local).AddTicks(7571));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataTimeRoute",
                schema: "data",
                table: "ReservedSeats");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 28, 17, 50, 30, 875, DateTimeKind.Local).AddTicks(7878));
        }
    }
}
