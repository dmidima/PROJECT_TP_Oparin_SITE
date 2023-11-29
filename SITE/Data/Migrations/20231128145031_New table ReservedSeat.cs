using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITE.Data.Migrations
{
    public partial class NewtableReservedSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DepartureTime",
                schema: "data",
                table: "DetailsRoutes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "data",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ReservedSeats",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    NameRoute = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedSeats", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "data",
                table: "ReservedSeats",
                columns: new[] { "Id", "Date", "NameRoute", "SeatNumber" },
                values: new object[] { 1, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Владимир-Иваново", 1 });

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 28, 17, 50, 30, 875, DateTimeKind.Local).AddTicks(7878));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservedSeats",
                schema: "data");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureTime",
                schema: "data",
                table: "DetailsRoutes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "data",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 25, 23, 43, 41, 574, DateTimeKind.Local).AddTicks(5047));
        }
    }
}
