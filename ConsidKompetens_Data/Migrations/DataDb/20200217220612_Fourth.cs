using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations.DataDb
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimePeriod",
                table: "ProjectModels");

            migrationBuilder.AddColumn<int>(
                name: "TimePeriodId",
                table: "ProjectModels",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TelephoneNumber",
                table: "OfficeModels",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "ProjectProfileRoles",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProfileRoles", x => new { x.ProjectId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_ProjectProfileRoles_ProfileModels_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfileModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProfileRoles_ProjectModels_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProfileRoles_RoleModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimePeriod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    Stop = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePeriod", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_TimePeriodId",
                table: "ProjectModels",
                column: "TimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProfileRoles_ProfileId",
                table: "ProjectProfileRoles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProfileRoles_RoleId",
                table: "ProjectProfileRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModels_TimePeriod_TimePeriodId",
                table: "ProjectModels",
                column: "TimePeriodId",
                principalTable: "TimePeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModels_TimePeriod_TimePeriodId",
                table: "ProjectModels");

            migrationBuilder.DropTable(
                name: "ProjectProfileRoles");

            migrationBuilder.DropTable(
                name: "TimePeriod");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModels_TimePeriodId",
                table: "ProjectModels");

            migrationBuilder.DropColumn(
                name: "TimePeriodId",
                table: "ProjectModels");

            migrationBuilder.AddColumn<string>(
                name: "TimePeriod",
                table: "ProjectModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TelephoneNumber",
                table: "OfficeModels",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
