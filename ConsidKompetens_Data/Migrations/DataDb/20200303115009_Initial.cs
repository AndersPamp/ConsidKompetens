using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations.DataDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkModels",
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
                    table.PrimaryKey("PK_LinkModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficeModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModel", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "ProfileModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    OwnerID = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    OfficeId = table.Column<int>(nullable: false),
                    ProfileImageId = table.Column<int>(nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    LinksId = table.Column<int>(nullable: true),
                    OfficeModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileModels_LinkModels_LinksId",
                        column: x => x.LinksId,
                        principalTable: "LinkModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileModels_OfficeModels_OfficeModelId",
                        column: x => x.OfficeModelId,
                        principalTable: "OfficeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileModels_ImageModels_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "ImageModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimePeriodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModels_TimePeriod_TimePeriodId",
                        column: x => x.TimePeriodId,
                        principalTable: "TimePeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    IconId = table.Column<int>(nullable: true),
                    ProfileModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceModels_ImageModels_IconId",
                        column: x => x.IconId,
                        principalTable: "ImageModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetenceModels_ProfileModels_ProfileModelId",
                        column: x => x.ProfileModelId,
                        principalTable: "ProfileModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProfileRoles",
                columns: table => new
                {
                    ProjectModelId = table.Column<int>(nullable: false),
                    ProfileModelId = table.Column<int>(nullable: false),
                    RoleModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProfileRoles", x => new { x.ProjectModelId, x.ProfileModelId, x.RoleModelId });
                    table.ForeignKey(
                        name: "FK_ProjectProfileRoles_ProfileModels_ProfileModelId",
                        column: x => x.ProfileModelId,
                        principalTable: "ProfileModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProfileRoles_ProjectModels_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProfileRoles_RoleModel_RoleModelId",
                        column: x => x.RoleModelId,
                        principalTable: "RoleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CompetenceModels_IconId",
                table: "CompetenceModels",
                column: "IconId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceModels_ProfileModelId",
                table: "CompetenceModels",
                column: "ProfileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_LinksId",
                table: "ProfileModels",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_OfficeModelId",
                table: "ProfileModels",
                column: "OfficeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_ProfileImageId",
                table: "ProfileModels",
                column: "ProfileImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModels_TimePeriodId",
                table: "ProjectModels",
                column: "TimePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProfileRoles_ProfileModelId",
                table: "ProjectProfileRoles",
                column: "ProfileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProfileRoles_RoleModelId",
                table: "ProjectProfileRoles",
                column: "RoleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TechniqueModel_ProjectModelId",
                table: "TechniqueModel",
                column: "ProjectModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenceModels");

            migrationBuilder.DropTable(
                name: "ProjectProfileRoles");

            migrationBuilder.DropTable(
                name: "TechniqueModel");

            migrationBuilder.DropTable(
                name: "ProfileModels");

            migrationBuilder.DropTable(
                name: "RoleModel");

            migrationBuilder.DropTable(
                name: "ProjectModels");

            migrationBuilder.DropTable(
                name: "LinkModels");

            migrationBuilder.DropTable(
                name: "OfficeModels");

            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.DropTable(
                name: "TimePeriod");
        }
    }
}
