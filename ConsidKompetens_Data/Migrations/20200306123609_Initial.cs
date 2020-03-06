using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsidKompetens_Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "062f39f9-5f27-476e-8bce-e7e447f8d874", 0, "a42d7741-bef1-499c-984f-78dfde8394dc", "test08@consid.se", true, false, null, "TEST08@CONSID.SE", "TEST08@CONSID.SE", "AQAAAAEAACcQAAAAEH+H4aWDMMUw2+5X3rd3QXksLo2N0ttyQPGp6amrO9h9zfpPl4JuvMaHrFi/jAcMrA==", null, false, "5Z4KSSACVENKW2F4TVO4N7XCCR6F6YMF", false, "test08@consid.se" },
                    { "1eb5b655-755d-4d21-b78c-8d19eeeb19a9", 0, "14cd057c-353b-407b-8dfa-5804c681d831", "test05@consid.se", true, false, null, "TEST05@CONSID.SE", "TEST05@CONSID.SE", "AQAAAAEAACcQAAAAEPsBbb71lZtdTapbTyDxxUVhJYISTvtunWps5B4NTKLigAkXTU06yBpyXU7/ex4t6w==", null, false, "FZ7WP5AIFFTV7HSNOGATMWQJODOGJCH5", false, "test05@consid.se" },
                    { "3a779fe9-15b0-4a10-b607-538393af8ed4", 0, "5b303bc4-71a3-4890-96b8-1929402dccd3", "test06@consid.se", true, false, null, "TEST08@CONSID.SE", "TEST06@CONSID.SE", "AQAAAAEAACcQAAAAEJYouQJ/yNR9wQoeOhwF49Hb+yWSLl+1ZcFG+txxHyTG5CFMqUcO+pwe5JqFtQW8PA==", null, false, "ZBTDM27HGFBTPCF2OKVTNT3W6TL4L5IO", false, "test06@consid.se" },
                    { "45f21477-00ef-436f-928b-504753249afa", 0, "45d838ba-f116-488d-9c61-3d33e95d0821", "test03@consid.se", true, false, null, "TEST03@CONSID.SE", "TEST03@CONSID.SE", "AQAAAAEAACcQAAAAEBukuiXoLi1UFKOy3ciTihooMYcxGKLjSGHZ5usGXL9GS2kriBVCOK5nCWdwQqs8HQ==", null, false, "R5GFLIMSYEXS7GD42SG5WZ2C5WYUTBRY", false, "test03@consid.se" },
                    { "65c97613-cd49-4aa8-ad5d-f53b05f609f9", 0, "086aef08-c584-4e6d-a209-05f606a046b1", "test04@consid.se", true, false, null, "TEST04@CONSID.SE", "TEST04@CONSID.SE", "AQAAAAEAACcQAAAAEHAYJycGYv6YVSCEndvwcJRKpAte1XYj7GWrpz/CHfPMYe4nyGBr23YN4uB4TugWeA==", null, false, "YCKY2RBQBWME52MQ47WMYH3J5DMFRLHS", false, "test04@consid.se" },
                    { "6c6c2eec-f58b-4728-8b6a-20492648ad83", 0, "f0375821-a978-45fa-bc87-f6abb3f28687", "test01@consid.se", true, false, null, "TEST01@CONSID.SE", "TEST01@CONSID.SE", "AQAAAAEAACcQAAAAEKVxOyt55J5c8FXP8u5PEuJ7u8RIoKSf8MzcUSrFKSkwKIUP9XmzLNY69MO/Y9dWHA==", null, false, "Z46LD455L6DQH6MX5IF45TW3FRBSXUOP", false, "test01@consid.se" },
                    { "84efc798-d9dd-48fe-ad64-e186488bfe88", 0, "108565f4-3fc9-42df-8116-cc25f1c305fe", "test09@consid.se", true, false, null, "TEST09@CONSID.SE", "TEST09@CONSID.SE", "AQAAAAEAACcQAAAAEMK2rT1kfBzfMpDWZvbz41enyW5smrBSAZbU0VJNB9xTev3HoRylwiL1gqHe6ta0Zg==", null, false, "FBZJKSHNPHDJNOC6YIFTRQYRKTQBWWZM", false, "test09@consid.se" },
                    { "b437b09d-615b-49ff-9317-bfab87d38c84", 0, "aeaa1a13-cda0-47f9-82be-779246b0a645", "test02@consid.se", true, false, null, "TEST02@CONSID.SE", "TEST02@CONSID.SE", "AQAAAAEAACcQAAAAEIBrSfEqoUYhAEzvJT+D4h0dYvZUx1DTQiDblQNlOwympB7kJmLUj3QYkRzgYcbW1A==", null, false, "XNTXT3KJOSOBTRJC4DSIFA3QDQYVQ3OU", false, "test02@consid.se" },
                    { "d3a961f6-603c-4c53-9e0b-3e49a81c7fc3", 0, "a9f4fc74-272d-4a11-86ef-c5c1a3484257", "test07@consid.se", true, false, null, "TEST07@CONSID.SE", "TEST07@CONSID.SE", "AQAAAAEAACcQAAAAEMHqg4+z3zu2R5Zq2NCWTM0+2uXLJr+SxSuuA2rDyBgV2Hfo63E5HECHq/2cjx0hVg==", null, false, "YU7JGCVN44WJDFH4GSHA4EKJI527DISU", false, "test07@consid.se" },
                    { "e9e8c451-f41c-4cf7-bfd0-07650578856e", 0, "cd651042-d2ad-41fb-b16a-728efe62e05b", "test10@consid.se", true, false, null, "TEST10@CONSID.SE", "TEST10@CONSID.SE", "AQAAAAEAACcQAAAAEPf5H1iZD2F1c8FkKTxpBfqL/bPXPuhGa5M2ZuBQ7Spkz6pYPQDvTbSA+msPSong6w==", null, false, "4QMMOJCAOGTBZWEDVBI2DTHF5SC66EFG", false, "test10@consid.se" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
