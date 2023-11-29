using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITE.Data.Migrations
{
    public partial class NewtableBookingSost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sostoania",
                schema: "data",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                column: "sostoania",
                value: "Подтвержден");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 28, 23, 30, 23, 630, DateTimeKind.Local).AddTicks(2277));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sostoania",
                schema: "data",
                table: "Bookings");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 28, 20, 45, 59, 46, DateTimeKind.Local).AddTicks(2841));
        }
    }
}
