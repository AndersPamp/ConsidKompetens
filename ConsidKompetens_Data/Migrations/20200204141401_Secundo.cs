using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations
{
    public partial class Secundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeUsers_OfficeModels_OfficeModelId",
                table: "EmployeeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeModels_RegionModels_RegionModelId",
                table: "OfficeModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_EmployeeUsers_EmployeeUserModelId",
                table: "ProjectModel");

            migrationBuilder.DropTable(
                name: "RegionModels");

            migrationBuilder.DropIndex(
                name: "IX_OfficeModels_RegionModelId",
                table: "OfficeModels");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeUsers_OfficeModelId",
                table: "EmployeeUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModel",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "OfficeModels");

            migrationBuilder.DropColumn(
                name: "RegionModelId",
                table: "OfficeModels");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "OfficeModels");

            migrationBuilder.DropColumn(
                name: "OfficeModelId",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmployeeUsers");

            migrationBuilder.RenameTable(
                name: "ProjectModel",
                newName: "ProjectModels");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModel_EmployeeUserModelId",
                table: "ProjectModels",
                newName: "IX_ProjectModels_EmployeeUserModelId");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "EmployeeUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeId",
                table: "EmployeeUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "EmployeeUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "EmployeeUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "ProjectModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Techniques",
                table: "ProjectModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TimePeriod",
                table: "ProjectModels",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModels",
                table: "ProjectModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_EmployeeUsers_EmployeeUserModelId",
                table: "ProjectModels",
                column: "EmployeeUserModelId",
                principalTable: "EmployeeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_EmployeeUsers_EmployeeUserModelId",
                table: "ProjectModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModels",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "Techniques",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "TimePeriod",
                table: "ProjectModels");

            migrationBuilder.RenameTable(
                name: "ProjectModels",
                newName: "ProjectModel");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModels_EmployeeUserModelId",
                table: "ProjectModel",
                newName: "IX_ProjectModel_EmployeeUserModelId");

            migrationBuilder.AddColumn<long>(
                name: "PostalCode",
                table: "OfficeModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "RegionModelId",
                table: "OfficeModels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "OfficeModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OfficeModelId",
                table: "EmployeeUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EmployeeUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModel",
                table: "ProjectModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RegionModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficeModels_RegionModelId",
                table: "OfficeModels",
                column: "RegionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUsers_OfficeModelId",
                table: "EmployeeUsers",
                column: "OfficeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeUsers_OfficeModels_OfficeModelId",
                table: "EmployeeUsers",
                column: "OfficeModelId",
                principalTable: "OfficeModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeModels_RegionModels_RegionModelId",
                table: "OfficeModels",
                column: "RegionModelId",
                principalTable: "RegionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_EmployeeUsers_EmployeeUserModelId",
                table: "ProjectModel",
                column: "EmployeeUserModelId",
                principalTable: "EmployeeUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
