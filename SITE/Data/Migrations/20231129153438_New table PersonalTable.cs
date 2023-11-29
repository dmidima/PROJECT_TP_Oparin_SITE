using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SITE.Data.Migrations
{
    public partial class NewtablePersonalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personals",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "data",
                table: "Personals",
                columns: new[] { "Id", "Job", "Name", "Surname", "WorkTime" },
                values: new object[] { 1, "Контроллер", "Дима", "Опарин", "8:00-17:00" });

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 29, 18, 34, 38, 117, DateTimeKind.Local).AddTicks(2679));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personals",
                schema: "data");

            migrationBuilder.UpdateData(
                schema: "data",
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthData",
                value: new DateTime(2003, 11, 29, 18, 13, 32, 132, DateTimeKind.Local).AddTicks(9118));
        }
    }
}
