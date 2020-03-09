using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations.DataDb
{
    public partial class Secundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProfileModels");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "ProfileModels",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 8,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 9,
                column: "Position",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 10,
                column: "Position",
                value: "Developer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "ProfileModels");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProfileModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "Developer");

            migrationBuilder.UpdateData(
                table: "ProfileModels",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "Developer");
        }
    }
}
