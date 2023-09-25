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
                    Verified = table.Column<bool>(type: "bit", nullable: false),
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
                    idPerson = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false)
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
                name: "tourPlan",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDriver = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime", nullable: false),
                    StopRequests = table.Column<int>(type: "int", nullable: true),
                    Eta = table.Column<TimeSpan>(type: "time", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLatitude = table.Column<double>(type: "float", nullable: false),
                    CurrentLongitude = table.Column<double>(type: "float", nullable: false)
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
                name: "passengerRequest",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idPerson = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    idTourPlan = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentLatitude = table.Column<double>(type: "float", nullable: false),
                    CurrentLongitude = table.Column<double>(type: "float", nullable: false),
                    isPending = table.Column<bool>(type: "bit", nullable: false),
                    isDenied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uDrive_passengerRequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_Person_PassengarRequests",
                        column: x => x.idPerson,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TourPlan_PassengarRequests",
                        column: x => x.idTourPlan,
                        principalSchema: "uDrive",
                        principalTable: "tourPlan",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PersonTourPlan",
                schema: "uDrive",
                columns: table => new
                {
                    AsPassengersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassengersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTourPlan", x => new { x.AsPassengersId, x.PassengersId });
                    table.ForeignKey(
                        name: "FK_PersonTourPlan_AspNetUsers_PassengersId",
                        column: x => x.PassengersId,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTourPlan_tourPlan_AsPassengersId",
                        column: x => x.AsPassengersId,
                        principalSchema: "uDrive",
                        principalTable: "tourPlan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2be1d292-4c01-4cfe-9cd8-c7b7012a5683", "2be1d292-4c01-4cfe-9cd8-c7b7012a5683", "Administrator", "ADMINISTRATOR" },
                    { "39f6894e-9781-4f87-9f23-8f145d7d1e33", "39f6894e-9781-4f87-9f23-8f145d7d1e33", "Person", "PERSON" },
                    { "96288eaf-d4d3-4937-a67f-346ccee73b73", "96288eaf-d4d3-4937-a67f-346ccee73b73", "Secretary", "SECRETARY" },
                    { "ce743c88-4ebd-4375-a627-387c69171052", "ce743c88-4ebd-4375-a627-387c69171052", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
                values: new object[,]
                {
                    { "167312eb-965f-4053-834f-eb8a9d6d11eb", 0, "4157289f-8b3b-4839-8264-8470a6ef2623", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEND1R0/z/oWlzA16FjIEmgs+A46Izey5AcfnLlzbVZ630IBXzIjBRFtNBXRaFCDtMg==", "0049619229040", true, "4aa05674-6a32-42bb-b8a8-4e423fff223a", false, "Person@udrive.de", false },
                    { "415fe08c-7c80-442f-981a-c1ecbe7b9daa", 0, "d4b44abe-4e14-4bbd-8968-4875b3ec93cd", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEKhEYfqf4SEPgiidjWoFZ1fOGPxUJwyMKpn2ZoEAris8rZChMSV+rDIEVbPOjcfq8Q==", "0049619229040", true, "73660b4a-8878-4ea5-bf5e-68efd95cc8de", false, "Administrator@udrive.de", false },
                    { "9f9b0461-ada7-4ec3-a7cd-44b66c6650cc", 0, "46d4c50f-8c33-4c2c-a797-c5f0883737c3", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEDZV2vp/+kmgfT/IS1GRz858Jmw0GUGIdNK9UDp7bp+GdJ2/heXNWZn9pCfIdk0Qkw==", "0049619229040", true, "74e384d6-ffc8-46c5-8ccf-659f7a9b6ad1", false, "Driver@udrive.de", false },
                    { "bbcb6bae-9fc7-47de-9d82-ad4dac5691ac", 0, "b30d3b5d-7234-4d36-ab74-b911ac76c866", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEMPsxnQzFEl6Woz7p9MXWZcTI4dstKbSPXI7w6uqp1/geC9c1MPgKl8ckCqPyxaE3Q==", "0049619229040", true, "d14fd0d5-6aa9-470f-a717-d200028ff80f", false, "Secretary@udrive.de", false }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "39f6894e-9781-4f87-9f23-8f145d7d1e33", "167312eb-965f-4053-834f-eb8a9d6d11eb" },
                    { "2be1d292-4c01-4cfe-9cd8-c7b7012a5683", "415fe08c-7c80-442f-981a-c1ecbe7b9daa" },
                    { "ce743c88-4ebd-4375-a627-387c69171052", "9f9b0461-ada7-4ec3-a7cd-44b66c6650cc" },
                    { "96288eaf-d4d3-4937-a67f-346ccee73b73", "bbcb6bae-9fc7-47de-9d82-ad4dac5691ac" }
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
                name: "IX_passengerRequest_idPerson",
                schema: "uDrive",
                table: "passengerRequest",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_passengerRequest_idTourPlan",
                schema: "uDrive",
                table: "passengerRequest",
                column: "idTourPlan");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTourPlan_PassengersId",
                schema: "uDrive",
                table: "PersonTourPlan",
                column: "PassengersId");

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
                name: "passengerRequest",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "PersonTourPlan",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "tourPlan",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "driver",
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
