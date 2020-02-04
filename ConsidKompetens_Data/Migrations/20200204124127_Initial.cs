using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<long>(nullable: false),
                    TelephoneNumber = table.Column<long>(nullable: false),
                    RegionModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeModels_RegionModels_RegionModelId",
                        column: x => x.RegionModelId,
                        principalTable: "RegionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    ProfileImageId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OfficeModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeUsers_OfficeModels_OfficeModelId",
                        column: x => x.OfficeModelId,
                        principalTable: "OfficeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeUsers_ImageModel_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "ImageModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    IconId = table.Column<Guid>(nullable: true),
                    EmployeeUserModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceModels_EmployeeUsers_EmployeeUserModelId",
                        column: x => x.EmployeeUserModelId,
                        principalTable: "EmployeeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetenceModels_ImageModel_IconId",
                        column: x => x.IconId,
                        principalTable: "ImageModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmployeeUserModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModel_EmployeeUsers_EmployeeUserModelId",
                        column: x => x.EmployeeUserModelId,
                        principalTable: "EmployeeUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceModels_EmployeeUserModelId",
                table: "CompetenceModels",
                column: "EmployeeUserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceModels_IconId",
                table: "CompetenceModels",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUsers_OfficeModelId",
                table: "EmployeeUsers",
                column: "OfficeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeUsers_ProfileImageId",
                table: "EmployeeUsers",
                column: "ProfileImageId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeModels_RegionModelId",
                table: "OfficeModels",
                column: "RegionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModel_EmployeeUserModelId",
                table: "ProjectModel",
                column: "EmployeeUserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenceModels");

            migrationBuilder.DropTable(
                name: "ProjectModel");

            migrationBuilder.DropTable(
                name: "EmployeeUsers");

            migrationBuilder.DropTable(
                name: "OfficeModels");

            migrationBuilder.DropTable(
                name: "ImageModel");

            migrationBuilder.DropTable(
                name: "RegionModels");
        }
    }
}
