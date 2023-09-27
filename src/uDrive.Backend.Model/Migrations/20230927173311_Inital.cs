using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Driver_Person",
                        column: x => x.idPerson,
                        principalSchema: "uDrive",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "08472ac6-afa5-4ad8-b3fb-e8935300a1a7", "08472ac6-afa5-4ad8-b3fb-e8935300a1a7", "Administrator", "ADMINISTRATOR" },
                    { "a7f16504-2bb3-4dee-9242-02f5109a3d97", "a7f16504-2bb3-4dee-9242-02f5109a3d97", "Secretary", "SECRETARY" },
                    { "dbe4e9ba-17ad-4c1e-88b6-bdb0daae8775", "dbe4e9ba-17ad-4c1e-88b6-bdb0daae8775", "Driver", "DRIVER" },
                    { "f9da1718-3815-4125-a8bb-a72404bd68cd", "f9da1718-3815-4125-a8bb-a72404bd68cd", "Person", "PERSON" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
                values: new object[,]
                {
                    { "5d04f148-3527-4f7c-b343-9a03e557faa7", 0, "b396d19d-29e2-4b76-a74d-3f4ff59730c1", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEIL0EdRPUdIfSbGNc5bKHWeRCp3kd6+/eNMkoe7+R8qPl7qrc/7wNTuRdoToY22b5Q==", "0049619229040", true, "1cfa8cac-8579-4009-8c66-d22bedf3575b", false, "Driver@udrive.de", false },
                    { "64457a76-580d-407c-9b04-06791f7960d5", 0, "ae9b0a96-37e1-423b-9d33-63dc64fcea04", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAED7ep8XQ55Ldl1fWZlCDjb0GN+o9h3GahbR23I6iyOBqbjHVDW3+bAheGi1pGrOFhg==", "0049619229040", true, "a69cb709-752e-419a-bc31-1e04c73a4423", false, "Person@udrive.de", false },
                    { "7b275be7-65d7-4aca-bd3e-b20119a2840e", 0, "8681d6f8-3533-4253-a711-6ca0949b48a7", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEFk0K2d+7/DIUPV/aAWL7osInqXUdhf8HnSnk6pmKIecypZEhVz2ojrhSr94DRkFCQ==", "0049619229040", true, "744c1c31-0432-446f-8221-0975a1f38ab0", false, "Administrator@udrive.de", false },
                    { "fdb668a2-2ff9-4afe-88bb-38239c56d3aa", 0, "f65461be-203e-4be4-9403-4e95ca683c50", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAELzmYLzXYWNso/0PExkBrYzoBPQz1Dfn5mx1P6ZVAH5q+cVUsmHezO2p2ffqPVVNaw==", "0049619229040", true, "258de42e-55ea-4b60-ae1e-f4dc87af5219", false, "Secretary@udrive.de", false }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "dbe4e9ba-17ad-4c1e-88b6-bdb0daae8775", "5d04f148-3527-4f7c-b343-9a03e557faa7" },
                    { "f9da1718-3815-4125-a8bb-a72404bd68cd", "64457a76-580d-407c-9b04-06791f7960d5" },
                    { "08472ac6-afa5-4ad8-b3fb-e8935300a1a7", "7b275be7-65d7-4aca-bd3e-b20119a2840e" },
                    { "a7f16504-2bb3-4dee-9242-02f5109a3d97", "fdb668a2-2ff9-4afe-88bb-38239c56d3aa" }
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
                column: "idDrivinglicense",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_driver_idPerson",
                schema: "uDrive",
                table: "driver",
                column: "idPerson",
                unique: true);

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
