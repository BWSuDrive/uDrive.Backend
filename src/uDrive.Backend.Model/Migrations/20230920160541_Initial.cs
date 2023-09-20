using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "uDrive");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "uDrive",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "uDrive",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "drivingLicence",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    expireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    licenceClass = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uDrive_drivingLicence", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weekday",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uDrive_weekday", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "uDrive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "uDrive",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "uDrive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "uDrive",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "uDrive",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "uDrive",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "uDrive",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idDrivinglicense = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    idPerson = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uDrive_driver", x => x.id);
                    table.ForeignKey(
                        name: "FK_Driver_DrivingLicence",
                        column: x => x.idDrivinglicense,
                        principalSchema: "uDrive",
                        principalTable: "drivingLicence",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Driver_Person",
                        column: x => x.idPerson,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "drivingSchedule",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    start = table.Column<TimeSpan>(type: "time", nullable: false),
                    arrival = table.Column<TimeSpan>(type: "time", nullable: false),
                    idWeekday = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uDrive_drivingSchedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_Weekday_DrivingSchedule",
                        column: x => x.idWeekday,
                        principalSchema: "uDrive",
                        principalTable: "weekday",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tourPlan",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDriver = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<TimeSpan>(type: "time", nullable: false),
                    StopRequests = table.Column<int>(type: "int", nullable: false),
                    Eta = table.Column<TimeSpan>(type: "time", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destiniation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uDrive_tourPlan", x => x.id);
                    table.ForeignKey(
                        name: "FK_TourPlan_Driver",
                        column: x => x.IdDriver,
                        principalSchema: "uDrive",
                        principalTable: "driver",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "drivingSchedule_driver",
                schema: "uDrive",
                columns: table => new
                {
                    drivingSchedule_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    driver_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__drivingS__1748636A316DE11E", x => new { x.drivingSchedule_id, x.driver_id });
                    table.ForeignKey(
                        name: "FK__drivingSc__drive__08B54D69",
                        column: x => x.driver_id,
                        principalSchema: "uDrive",
                        principalTable: "driver",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__drivingSc__drivi__07C12930",
                        column: x => x.drivingSchedule_id,
                        principalSchema: "uDrive",
                        principalTable: "drivingSchedule",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "spontanesDrive",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    idDrivingScheduleOverwrite = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uDrive_spontanesDrive", x => x.id);
                    table.ForeignKey(
                        name: "FK_DrivingSchedule_SpontanesDrive",
                        column: x => x.idDrivingScheduleOverwrite,
                        principalSchema: "uDrive",
                        principalTable: "drivingSchedule",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9abfa5ff-4347-4e81-8cc3-de6c41661432", "9abfa5ff-4347-4e81-8cc3-de6c41661432", "Person", "PERSON" },
                    { "e17eb711-64b1-4d81-9fa5-87ba617ea84a", "e17eb711-64b1-4d81-9fa5-87ba617ea84a", "Secretary", "SECRETARY" },
                    { "f09273cd-1adf-4a13-b797-267585e68d6d", "f09273cd-1adf-4a13-b797-267585e68d6d", "Driver", "DRIVER" },
                    { "fdfd6951-1a19-4dbe-b7eb-9589dc634d62", "fdfd6951-1a19-4dbe-b7eb-9589dc634d62", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "60f9d742-6fd6-445e-8c02-055ec70ab9dd", 0, "e9b59417-9016-4d8f-8e32-e03113c45255", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEJWTrHSpKCI14MIRY+fAEL1cZgslctjPu8D2O/t7+KFmIxEg2AJPj5plCyFtlZSDgA==", null, false, "0dead13b-cd93-4b07-b87d-d4bd7381d374", false, "Person@udrive.de" },
                    { "8ee9da42-1303-42be-81d9-aadf42a9d655", 0, "acadca04-ad7a-446a-878c-f79bfc561571", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEKRFmxvxYmdMAkofPJfiQOHBKfCEdk4DIjIbGu5CEAlawx8hlLT0BkuD+6PEVM3AIA==", null, false, "d8c54738-c0a5-4e44-a5eb-0ff1b56feaa7", false, "Secretary@udrive.de" },
                    { "af41d9ec-9e71-4a9c-b7ab-443bce642e7e", 0, "5825af23-28a7-4405-87e7-199184598e7b", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEPi3rOvpBZl6AnW+Bi8BWaC10Lu+N7D4e5qgXFMmth0KeWxyPJ//AQpLI+TmhH19nA==", null, false, "52625683-3f82-4c02-99d5-99ab6ed48aff", false, "Driver@udrive.de" },
                    { "dddc8bba-ab43-454c-ba57-0a61f456af7e", 0, "7cd5d28e-1e8a-4b91-bac1-3f4e2befddd9", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEOI36ZnPQZEzzAIe5gQzr9zAuEOjv4uigPbjfRTungnM3y9r5MoNhIvFT1217gOcPQ==", null, false, "8b7684fe-98d6-4fb6-bbde-9162dc2b9d07", false, "Administrator@udrive.de" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9abfa5ff-4347-4e81-8cc3-de6c41661432", "60f9d742-6fd6-445e-8c02-055ec70ab9dd" },
                    { "e17eb711-64b1-4d81-9fa5-87ba617ea84a", "8ee9da42-1303-42be-81d9-aadf42a9d655" },
                    { "f09273cd-1adf-4a13-b797-267585e68d6d", "af41d9ec-9e71-4a9c-b7ab-443bce642e7e" },
                    { "fdfd6951-1a19-4dbe-b7eb-9589dc634d62", "dddc8bba-ab43-454c-ba57-0a61f456af7e" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "uDrive",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "uDrive",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "uDrive",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "uDrive",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "uDrive",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "uDrive",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "uDrive",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_driver_idDrivinglicense",
                schema: "uDrive",
                table: "driver",
                column: "idDrivinglicense");

            migrationBuilder.CreateIndex(
                name: "IX_driver_idPerson",
                schema: "uDrive",
                table: "driver",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_drivingSchedule_idWeekday",
                schema: "uDrive",
                table: "drivingSchedule",
                column: "idWeekday");

            migrationBuilder.CreateIndex(
                name: "IX_drivingSchedule_driver_driver_id",
                schema: "uDrive",
                table: "drivingSchedule_driver",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_spontanesDrive_idDrivingScheduleOverwrite",
                schema: "uDrive",
                table: "spontanesDrive",
                column: "idDrivingScheduleOverwrite");

            migrationBuilder.CreateIndex(
                name: "IX_tourPlan_IdDriver",
                schema: "uDrive",
                table: "tourPlan",
                column: "IdDriver");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "drivingSchedule_driver",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "spontanesDrive",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "tourPlan",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "drivingSchedule",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "driver",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "weekday",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "drivingLicence",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "uDrive");
        }
    }
}
