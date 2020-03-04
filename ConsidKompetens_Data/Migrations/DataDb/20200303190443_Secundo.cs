using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations.DataDb
{
    public partial class Secundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceModels_ImageModels_IconId",
                table: "CompetenceModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceModels_ProfileModels_ProfileModelId",
                table: "CompetenceModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceModels",
                table: "CompetenceModels");

            migrationBuilder.DropIndex(
                name: "IX_CompetenceModels_IconId",
                table: "CompetenceModels");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "CompetenceModels");

            migrationBuilder.DropColumn(
                name: "IconId",
                table: "CompetenceModels");

            migrationBuilder.RenameTable(
                name: "CompetenceModels",
                newName: "CompetenceModel");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceModels_ProfileModelId",
                table: "CompetenceModel",
                newName: "IX_CompetenceModel_ProfileModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceModel",
                table: "CompetenceModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceModel_ProfileModels_ProfileModelId",
                table: "CompetenceModel",
                column: "ProfileModelId",
                principalTable: "ProfileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceModel_ProfileModels_ProfileModelId",
                table: "CompetenceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceModel",
                table: "CompetenceModel");

            migrationBuilder.RenameTable(
                name: "CompetenceModel",
                newName: "CompetenceModels");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceModel_ProfileModelId",
                table: "CompetenceModels",
                newName: "IX_CompetenceModels_ProfileModelId");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "CompetenceModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IconId",
                table: "CompetenceModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceModels",
                table: "CompetenceModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceModels_IconId",
                table: "CompetenceModels",
                column: "IconId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceModels_ImageModels_IconId",
                table: "CompetenceModels",
                column: "IconId",
                principalTable: "ImageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceModels_ProfileModels_ProfileModelId",
                table: "CompetenceModels",
                column: "ProfileModelId",
                principalTable: "ProfileModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
