using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations.DataDb
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileModels_RoleModel_RoleId",
                table: "ProfileModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProfileRoles_RoleModel_RoleId",
                table: "ProjectProfileRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProfileRoles",
                table: "ProjectProfileRoles");

            migrationBuilder.DropIndex(
                name: "IX_ProfileModels_RoleId",
                table: "ProfileModels");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ProfileModels");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "ProjectProfileRoles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProfileRoles",
                table: "ProjectProfileRoles",
                columns: new[] { "ProjectId", "ProfileId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProfileRoles_RoleModel_RoleId",
                table: "ProjectProfileRoles",
                column: "RoleId",
                principalTable: "RoleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProfileRoles_RoleModel_RoleId",
                table: "ProjectProfileRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProfileRoles",
                table: "ProjectProfileRoles");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "ProjectProfileRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "ProfileModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProfileRoles",
                table: "ProjectProfileRoles",
                columns: new[] { "ProjectId", "ProfileId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_RoleId",
                table: "ProfileModels",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileModels_RoleModel_RoleId",
                table: "ProfileModels",
                column: "RoleId",
                principalTable: "RoleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProfileRoles_RoleModel_RoleId",
                table: "ProjectProfileRoles",
                column: "RoleId",
                principalTable: "RoleModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
