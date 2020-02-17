using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations.DataDb
{
    public partial class Secundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_ProfileModels_ProfileModelId",
                table: "ProjectModels");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModels_ProfileModelId",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "ProfileModelId",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "Techniques",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ProfileModels");

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "ProfileModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "ProfileModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProjectModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModel_ProjectModels_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TechniqueModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProjectModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechniqueModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechniqueModel_ProjectModels_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_ProjectModelId",
                table: "ProfileModels",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_RoleId",
                table: "ProfileModels",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModel_ProjectModelId",
                table: "RoleModel",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueModel_ProjectModelId",
                table: "TechniqueModel",
                column: "ProjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModels_ProjectModels_ProjectModelId",
                table: "ProfileModels",
                column: "ProjectModelId",
                principalTable: "ProjectModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModels_RoleModel_RoleId",
                table: "ProfileModels",
                column: "RoleId",
                principalTable: "RoleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModels_ProjectModels_ProjectModelId",
                table: "ProfileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModels_RoleModel_RoleId",
                table: "ProfileModels");

            migrationBuilder.DropTable(
                name: "RoleModel");

            migrationBuilder.DropTable(
                name: "TechniqueModel");

            migrationBuilder.DropIndex(
                name: "IX_ProfileModels_ProjectModelId",
                table: "ProfileModels");

            migrationBuilder.DropIndex(
                name: "IX_ProfileModels_RoleId",
                table: "ProfileModels");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "ProfileModels");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ProfileModels");

            migrationBuilder.AddColumn<int>(
                name: "ProfileModelId",
                table: "ProjectModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "ProjectModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Techniques",
                table: "ProjectModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "ProfileModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_ProfileModelId",
                table: "ProjectModels",
                column: "ProfileModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_ProfileModels_ProfileModelId",
                table: "ProjectModels",
                column: "ProfileModelId",
                principalTable: "ProfileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
