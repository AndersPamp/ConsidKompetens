using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations.ProfileData
{
    public partial class secundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinksId",
                table: "ProfileModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "CompetenceModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LinkModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    LinkedInUrl = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true),
                    InstagramUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_LinksId",
                table: "ProfileModels",
                column: "LinksId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModels_LinkModel_LinksId",
                table: "ProfileModels",
                column: "LinksId",
                principalTable: "LinkModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModels_LinkModel_LinksId",
                table: "ProfileModels");

            migrationBuilder.DropTable(
                name: "LinkModel");

            migrationBuilder.DropIndex(
                name: "IX_ProfileModels_LinksId",
                table: "ProfileModels");

            migrationBuilder.DropColumn(
                name: "LinksId",
                table: "ProfileModels");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "CompetenceModels");
        }
    }
}
