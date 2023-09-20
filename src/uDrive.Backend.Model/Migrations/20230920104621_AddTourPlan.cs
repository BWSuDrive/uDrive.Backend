using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddTourPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18c3884c-2091-4944-b0cd-5ebf17092458", "29c18bb9-34ec-4f0b-aff7-50f8d78ea4cc" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "554eb2b3-bb72-4b98-906c-961a2df7c598", "2c498d17-4ec6-40b5-93b2-56e83e5498e2" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2eab8f6-d599-4fe9-9d77-18fa45a20068", "da58ee98-8702-4bde-99e7-07ddfb413c46" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf", "f5f7ce85-b383-4368-a969-af31e28463a1" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c3884c-2091-4944-b0cd-5ebf17092458");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "554eb2b3-bb72-4b98-906c-961a2df7c598");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2eab8f6-d599-4fe9-9d77-18fa45a20068");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29c18bb9-34ec-4f0b-aff7-50f8d78ea4cc");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c498d17-4ec6-40b5-93b2-56e83e5498e2");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da58ee98-8702-4bde-99e7-07ddfb413c46");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5f7ce85-b383-4368-a969-af31e28463a1");

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
                    table.PrimaryKey("PK_tourPlan", x => x.id);
                    table.ForeignKey(
                        name: "FK_TourPlan_Driver",
                        column: x => x.IdDriver,
                        principalSchema: "uDrive",
                        principalTable: "driver",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cdc6dc0-06bc-47cd-acf4-1ff77d9809fe", "6cdc6dc0-06bc-47cd-acf4-1ff77d9809fe", "Secretary", "SECRETARY" },
                    { "eac11724-f0e5-4ace-b343-f95a4470a0f4", "eac11724-f0e5-4ace-b343-f95a4470a0f4", "Person", "PERSON" },
                    { "eb8ca7dc-2d36-4026-92f8-1137d4513dde", "eb8ca7dc-2d36-4026-92f8-1137d4513dde", "Administrator", "ADMINISTRATOR" },
                    { "fb41809c-48d3-4345-9780-6fe200cef640", "fb41809c-48d3-4345-9780-6fe200cef640", "Driver", "DRIVER" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1c5499de-7b5d-426f-8b5f-dde081486632", 0, "1d8acea1-5798-491a-a73e-bca37090ac8c", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEEoZgmMr12TnReRMrRb8JvAYtN0Jb/KKDDL63ogkTlrPYeea8ia7vwo8JmbPxtkfXw==", null, false, "3c4fdc5b-5697-4b31-b970-2b31de50950c", false, "Driver@udrive.de" },
                    { "a7894d74-f4ed-4ff1-b08d-478955a32830", 0, "b5668bf1-07c1-4143-86bd-68a89342fa23", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEBWSY3Wj6opqRfxXInLe56eYvMi6h8q8wr/b3bmglbfH5Bgxj+7WzD9xktyZ0XVMIA==", null, false, "43c1a62a-0cc3-4439-9915-780133b72ce6", false, "Administrator@udrive.de" },
                    { "aa3ac560-2ff0-4dfc-87a3-cb0b01dffcc5", 0, "deebed82-1701-4211-81eb-e55c35f0ca5f", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEPRpyugT3GHuK3M1whTUpTrpk8UzvNnxwXsLjuUNMxl3mYxnlGVj6DY1vnatS3o1Mw==", null, false, "d254865a-7c2b-48a1-936f-8afa83e8d48c", false, "Secretary@udrive.de" },
                    { "e3ba660c-8c4c-4b3d-8385-9f9fd6ff545a", 0, "d023f314-3a82-40f0-a841-48b87d8fc6e2", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEPFooXIDgUhKSC24oVBJdqBa1toV0FRADUeJQVUIaznsLoCkAFt8vZ406fZyl5fwog==", null, false, "804cb569-9042-46fe-ab18-bb37e0b3ae25", false, "Person@udrive.de" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fb41809c-48d3-4345-9780-6fe200cef640", "1c5499de-7b5d-426f-8b5f-dde081486632" },
                    { "eb8ca7dc-2d36-4026-92f8-1137d4513dde", "a7894d74-f4ed-4ff1-b08d-478955a32830" },
                    { "6cdc6dc0-06bc-47cd-acf4-1ff77d9809fe", "aa3ac560-2ff0-4dfc-87a3-cb0b01dffcc5" },
                    { "eac11724-f0e5-4ace-b343-f95a4470a0f4", "e3ba660c-8c4c-4b3d-8385-9f9fd6ff545a" }
                });

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
                name: "tourPlan",
                schema: "uDrive");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb41809c-48d3-4345-9780-6fe200cef640", "1c5499de-7b5d-426f-8b5f-dde081486632" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eb8ca7dc-2d36-4026-92f8-1137d4513dde", "a7894d74-f4ed-4ff1-b08d-478955a32830" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6cdc6dc0-06bc-47cd-acf4-1ff77d9809fe", "aa3ac560-2ff0-4dfc-87a3-cb0b01dffcc5" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eac11724-f0e5-4ace-b343-f95a4470a0f4", "e3ba660c-8c4c-4b3d-8385-9f9fd6ff545a" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cdc6dc0-06bc-47cd-acf4-1ff77d9809fe");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eac11724-f0e5-4ace-b343-f95a4470a0f4");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb8ca7dc-2d36-4026-92f8-1137d4513dde");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb41809c-48d3-4345-9780-6fe200cef640");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c5499de-7b5d-426f-8b5f-dde081486632");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7894d74-f4ed-4ff1-b08d-478955a32830");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa3ac560-2ff0-4dfc-87a3-cb0b01dffcc5");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3ba660c-8c4c-4b3d-8385-9f9fd6ff545a");

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18c3884c-2091-4944-b0cd-5ebf17092458", "18c3884c-2091-4944-b0cd-5ebf17092458", "Secretary", "SECRETARY" },
                    { "554eb2b3-bb72-4b98-906c-961a2df7c598", "554eb2b3-bb72-4b98-906c-961a2df7c598", "Administrator", "ADMINISTRATOR" },
                    { "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf", "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf", "Driver", "DRIVER" },
                    { "d2eab8f6-d599-4fe9-9d77-18fa45a20068", "d2eab8f6-d599-4fe9-9d77-18fa45a20068", "Person", "PERSON" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29c18bb9-34ec-4f0b-aff7-50f8d78ea4cc", 0, "2b047410-c562-4400-8766-f5a317025938", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEMGF68CpO17D8oko+hnjZUXFcZGjRiNhB5m26AoBxJ1XprtdZ1n4V1BtKl3LRcIAWA==", null, false, "1280b489-0940-4bad-83e0-421c6cc6f5ec", false, "Secretary@udrive.de" },
                    { "2c498d17-4ec6-40b5-93b2-56e83e5498e2", 0, "2ac10161-c31f-4987-9920-c5bfa35672cf", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEDP5JkgtHOdNTiOTz+fCwA1nERS1gKL++MWeIqmYHHfiIHTQS3u32Zj3M5d5U3n+Hg==", null, false, "c1bd93ac-e43e-48de-9743-81dd6441927a", false, "Administrator@udrive.de" },
                    { "da58ee98-8702-4bde-99e7-07ddfb413c46", 0, "3c3d5b1b-77ab-4ec9-96a6-87c89271e7e3", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEAMfTuaqiY57m/TvuANyJHUqwtCeTcN+Fp8D+zsZQGInjELOd20q8ZazW2Lhzw6gPQ==", null, false, "986c7bfa-00f6-4496-92f0-10e0e20ad51c", false, "Person@udrive.de" },
                    { "f5f7ce85-b383-4368-a969-af31e28463a1", 0, "45922ec3-c79f-43fd-9da1-adfc13faa883", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAECBNUNl8oEQ998f+kW4qbiqWBxCbQmS1nOaxt8/wKKp2dI+ReGmQlzKBTcmN1tlM4A==", null, false, "744f0586-48c2-4989-89df-ca3b77c9db66", false, "Driver@udrive.de" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "18c3884c-2091-4944-b0cd-5ebf17092458", "29c18bb9-34ec-4f0b-aff7-50f8d78ea4cc" },
                    { "554eb2b3-bb72-4b98-906c-961a2df7c598", "2c498d17-4ec6-40b5-93b2-56e83e5498e2" },
                    { "d2eab8f6-d599-4fe9-9d77-18fa45a20068", "da58ee98-8702-4bde-99e7-07ddfb413c46" },
                    { "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf", "f5f7ce85-b383-4368-a969-af31e28463a1" }
                });
        }
    }
}
