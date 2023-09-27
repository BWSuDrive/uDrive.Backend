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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "5ab3e8a8-ba3e-44eb-b53f-9a0f82640272", "5ab3e8a8-ba3e-44eb-b53f-9a0f82640272", "Person", "PERSON" },
                    { "a0523c72-95c5-4c8d-aefd-ab5d51dd91b6", "a0523c72-95c5-4c8d-aefd-ab5d51dd91b6", "Secretary", "SECRETARY" },
                    { "b17b4cd4-3c4a-4f89-a7e5-f88405f27dd6", "b17b4cd4-3c4a-4f89-a7e5-f88405f27dd6", "Driver", "DRIVER" },
                    { "bc56875b-72bf-4c07-bc14-b41766715d02", "bc56875b-72bf-4c07-bc14-b41766715d02", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
                values: new object[,]
                {
                    { "667b8877-92d3-4fca-8ceb-6658714ab9ff", 0, "d542d0a6-ef4d-40b4-9208-13c633415c5d", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEAXYx2B5If49Z7eusofWDeH8VyVSlJ1cjauZqgd5tQ1HsJsfpMvYy9TJqssasdoNew==", "0049619229040", true, "91be4285-5345-43f1-a57d-e0c44da26d06", false, "Secretary@udrive.de", false },
                    { "691559b0-1394-48e3-a4d7-39270761b625", 0, "2017e71b-5ee8-4470-9d58-38764205f3b5", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEDK7kffCDQj4zJx9nIc2d0Oagf6007Irl5l1HLoICWb2LSVF2JuKl8cjMEcKI18v5g==", "0049619229040", true, "ac2df993-57e5-4ca4-9b03-c175a747e646", false, "Person@udrive.de", false },
                    { "be002a19-4554-473d-a262-a62b2e75c176", 0, "444a0675-674f-461c-906c-2bf3ce860886", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEAAvxwGMm3VbTm6GigbNr8y9kKHAK2vHQrGwbzKtcqHT1EBEfZ4H0fdRyhUNAXI/uQ==", "0049619229040", true, "0a72d943-f3b4-41cf-9374-b1af61c47afe", false, "Administrator@udrive.de", false },
                    { "db960c2a-dc60-492b-ae56-90c4e2f36f89", 0, "f880e9e2-bb5b-4f74-bb7d-8ab0addf227a", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEKQAJhmD6C5LSzdb4/7Aq//NZZa9masT63EQrlKpQPFRAAceA+OYZCkp1BpDedlz2w==", "0049619229040", true, "0f5bea06-8ab0-404b-bc5d-0402ac126f36", false, "Driver@udrive.de", false }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a0523c72-95c5-4c8d-aefd-ab5d51dd91b6", "667b8877-92d3-4fca-8ceb-6658714ab9ff" },
                    { "5ab3e8a8-ba3e-44eb-b53f-9a0f82640272", "691559b0-1394-48e3-a4d7-39270761b625" },
                    { "bc56875b-72bf-4c07-bc14-b41766715d02", "be002a19-4554-473d-a262-a62b2e75c176" },
                    { "b17b4cd4-3c4a-4f89-a7e5-f88405f27dd6", "db960c2a-dc60-492b-ae56-90c4e2f36f89" }
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
