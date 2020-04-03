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
                name: "TimePeriods",
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
                    table.PrimaryKey("PK_TimePeriods", x => x.Id);
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
                    Position = table.Column<string>(nullable: true),
                    ImageModelId = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    LinkedInUrl = table.Column<string>(nullable: true),
                    ResumeUrl = table.Column<string>(nullable: true),
                    OfficeModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileModels_ImageModels_ImageModelId",
                        column: x => x.ImageModelId,
                        principalTable: "ImageModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileModels_OfficeModels_OfficeModelId",
                        column: x => x.OfficeModelId,
                        principalTable: "OfficeModels",
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
                    TimePeriodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModels_TimePeriods_TimePeriodId",
                        column: x => x.TimePeriodId,
                        principalTable: "TimePeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    CompId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProfileModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceModels", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "ImageModels",
                columns: new[] { "Id", "Alt", "Created", "Modified", "Url" },
                values: new object[,]
                {
                    { 1, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\6c6c2eec-f58b-4728-8b6a-20492648ad83.jpeg" },
                    { 9, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\84efc798-d9dd-48fe-ad64-e186488bfe88.jpeg" },
                    { 8, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\062f39f9-5f27-476e-8bce-e7e447f8d874.jpeg" },
                    { 7, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\d3a961f6-603c-4c53-9e0b-3e49a81c7fc3.jpeg" },
                    { 6, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\3a779fe9-15b0-4a10-b607-538393af8ed4.jpeg" },
                    { 10, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\e9e8c451-f41c-4cf7-bfd0-07650578856e.jpeg" },
                    { 4, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\65c97613-cd49-4aa8-ad5d-f53b05f609f9.jpeg" },
                    { 3, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\45f21477-00ef-436f-928b-504753249afa.jpeg" },
                    { 2, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\b437b09d-615b-49ff-9317-bfab87d38c84.jpeg" },
                    { 5, "Profile image", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "../ConsidKompetens_Data/ProfileImages\\1eb5b655-755d-4d21-b78c-8d19eeeb19a9.jpeg" }
                });

            migrationBuilder.InsertData(
                table: "OfficeModels",
                columns: new[] { "Id", "City", "Created", "Modified", "TelephoneNumber" },
                values: new object[,]
                {
                    { 13, "Sundsvall", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 21, "Kalmar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 20, "Karlshamn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 19, "Nyköping", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 18, "Växjö", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 17, "Borås", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 16, "Västerås", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 15, "Karlskrona", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 14, "Värnamo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 12, "Ljungby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 10, "Helsingborg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 2, "Stockholm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 9, "Örebro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 8, "Norrköping", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 7, "Linköping", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 6, "Uppsala", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 5, "Malmö", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 4, "Göteborg - Paradigm", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "+46 31 761 56 10" },
                    { 3, "Göteborg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 11, "Gävle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" },
                    { 1, "Jönköping", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "036-120210" }
                });

            migrationBuilder.InsertData(
                table: "RoleModel",
                columns: new[] { "Id", "Created", "Modified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend developer" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend developer" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solution architect" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project leader" }
                });

            migrationBuilder.InsertData(
                table: "TimePeriods",
                columns: new[] { "Id", "Created", "Modified", "Start", "Stop" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1998), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1984) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1992), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1980) },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1994), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1959) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1986), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1974) }
                });

            migrationBuilder.InsertData(
                table: "ProfileModels",
                columns: new[] { "Id", "AboutMe", "Created", "Experience", "FirstName", "ImageModelId", "LastName", "LinkedInUrl", "Modified", "OfficeModelId", "OwnerID", "Position", "ResumeUrl" },
                values: new object[,]
                {
                    { 1, "I am oddly aroused by no crazy chicks see, I told you you're going to be trained to my satisfaction. Unworthy of serious consideration when I picked this username I didn't realize I couldn't change it if you have to look it up don't bother on the first date I should have grown up in the 40s, shooting it depends on the night you're going to be trained to my satisfaction I'm kind of a genius it's huge. Cosplay I despise my wife if you like my profile younger women ultramarathons.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 3, "John", 1, "Doe", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "6c6c2eec-f58b-4728-8b6a-20492648ad83", "Developer", null },
                    { 2, "Complete lack of shame is probably a conspiracy documentary filmmaker I attract girls who are very good-looking. I may be somewhat jaded unworthy of serious consideration I am extremely experienced and talented beekeeping I love the smell of, no crazy chicks I will love you forever I attract girls who are very good-looking females I grow a creepy mustache every February. Clubbing bald is sexy you should message me I'm an enormous man-child staying up late I may be somewhat jaded.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 7, "Idi", 2, "Amin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "b437b09d-615b-49ff-9317-bfab87d38c84", "Developer", null },
                    { 3, "If you like please post your real pictures I am oddly aroused by it depends on the night. Shooting laughing hysterically laughing hysterically I should have grown up in the 40s performance art, if that paragraph above turned you off nubile snapchat The Game I am a gentleman first and foremost. I did a lot of modeling work in the mid-80s that just proves my point MFA unworthy of serious consideration my beard when I picked this username I didn't realize I couldn't change it.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 12, "Hozni", 3, "Mubarak", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "45f21477-00ef-436f-928b-504753249afa", "Developer", null },
                    { 4, "Please post your real pictures heyyy my deep, manly voice P90X. If you dress up like a pin-up doll for me The Game shooting Juggalo with morals, complete lack of shame if you like my profile Ayn Rand no crazy chicks I will love you forever. I despise I'm really good at I'm a nice guy my deep, manly voice I am a hoarder, but only of top shelf stuff I won't bite without permission.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 6, "Elisabeth", 4, "Höglund", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "65c97613-cd49-4aa8-ad5d-f53b05f609f9", "Developer", null },
                    { 5, "If you have an innie belly button you could say I'm old-fashioned MFA on the first date. When I get drunk I don't really keep a budget everything destructive that I do I attract girls who are very good-looking if that paragraph above turned you off, nubile proper grammar I live in constant amazement of nature and the universe please post your real pictures bald is sexy. I love the smell of I'm really good at my other half if you like are you really going to rule me out becausae of it? my last partner told me.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 5, "Djingis", 5, "Khan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "1eb5b655-755d-4d21-b78c-8d19eeeb19a9", "Developer", null },
                    { 6, "My lizard tongue blackjack with morals well-built. Heyyy Think about it! making others feel good females my last partner told me, I'm an enormous man-child other shenanigans keep up with me skydiving well-built. On my fetish list I'm an enormous man-child shooting that just proves my point shooting size 2.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 8, "Emperor", 6, "Hirohito", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "3a779fe9-15b0-4a10-b607-538393af8ed4", "Developer", null },
                    { 7, "A fairly successful career in sports performance art years ago I discovered unworthy of serious consideration. The Game that's what she said proper grammar with lots of self-respect wildly attractive doesn't hurt, when I picked this username I didn't realize I couldn't change it I despise I grow a creepy mustache every February staying up late complete lack of shame. Someone to provide for you is pretty awesome working on my screenplay I don't really read much these days everything destructive that I do or so I've been told.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 2, "Reinhard", 7, "Heydrich", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "d3a961f6-603c-4c53-9e0b-3e49a81c7fc3", "Developer", null },
                    { 8, "If I make fun of you it's because I like you it's huge pics on request I'm really good at. I am a hoarder, but only of top shelf stuff you could say I'm old-fashioned I will love you forever if you like documentary filmmaker, heyyy I will love you forever Libertarian Ayn Rand unworthy of serious consideration. Making others feel good I don't really read much these days you need a real man I grow a creepy mustache every February playing devil's advocate crying in my bathtub.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 0, "Hatte", 8, "Furuhagen", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "062f39f9-5f27-476e-8bce-e7e447f8d874", "Developer", null },
                    { 9, "Be my partner in crime is probably a conspiracy very successsful entrepreneur I will love you forever. In my birthday suit organized chaos I grow a creepy mustache every February organized chaos I am a hoarder, but only of top shelf stuff, proper grammar Juggalo ages 18 - 22 well-built for real though. Living on sailboats or so I've been told if you have to look it up don't bother you should message me I starred in my own reality show The Game.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 22, "Biskop", 9, "Brask", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "84efc798-d9dd-48fe-ad64-e186488bfe88", "Developer", null },
                    { 10, "If you have an innie belly button my other half work hard play hard because I am a paradox. I have an IQ of 140, which means complete lack of shame I am a hoarder, but only of top shelf stuff if you dress up like a pin-up doll for me playing devil's advocate, it's huge looking for a third Libertarian extreme living on sailboats. MFA years ago I discovered Juggalo are you really going to rule me out becausae of it? I did a lot of modeling work in the mid-80s but I only smoke when drinking.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), 14, "Griselda", 10, "Blanco", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), null, "e9e8c451-f41c-4cf7-bfd0-07650578856e", "Developer", null }
                });

            migrationBuilder.InsertData(
                table: "ProjectModels",
                columns: new[] { "Id", "Created", "Description", "Modified", "Name", "TimePeriodId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "My alter-ego is crossfit giving massages if you like. For real though I live in constant amazement of nature and the universe I don't really read much these days extreme Juggalo, I have an IQ of 140, which means staying up late if you have to look it up don't bother work hard play hard trapped in a sexless marriage. When I get drunk I am extremely experienced and talented you should message me Libertarian my beard my deep, manly voice.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Öresundskraft", 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Is pretty awesome that means I am wonderful crossfit performance art. I hope there are good girls left extreme blackjack see, I told you in my birthday suit, if you have a BMI under 25 keep up with me I starred in my own reality show bald is sexy it's huge. Working on my screenplay dive bars laughing hysterically MFA I'm a nice guy clubbing.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Peab", 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Living on sailboats most cats eventually love me is probably a conspiracy my lizard tongue. Most cats eventually love me I know shirtless pics are a no-no, but P90X P90X full-contact, I will love you forever the fact that you are even considering schooling me I am a gentleman first and foremost I'm the last of a dying breed if you have an innie belly button. I may be somewhat jaded someone to provide for you if I make fun of you it's because I like you you're going to be trained to my satisfaction is pretty awesome I don't really read much these days.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Vinslövs Bangolf", 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Most cats eventually love me proper grammar most cats eventually love me dive bars. I am a hoarder, but only of top shelf stuff throwing rocks at trains I starred in my own reality show staying up late motorcycle collection, I have an IQ of 140, which means if you dress up like a pin-up doll for me extreme everything destructive that I do full-contact. Really only soft drugs size 2 throwing rocks at trains friendzone one time in middle school I don't really keep a budget.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "Kenneths Kennel & Kebab", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceModels_ProfileModelId",
                table: "CompetenceModels",
                column: "ProfileModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_ImageModelId",
                table: "ProfileModels",
                column: "ImageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileModels_OfficeModelId",
                table: "ProfileModels",
                column: "OfficeModelId");

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
                name: "ImageModels");

            migrationBuilder.DropTable(
                name: "OfficeModels");

            migrationBuilder.DropTable(
                name: "TimePeriods");
        }
    }
}
