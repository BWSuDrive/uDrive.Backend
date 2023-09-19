using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Person",
                schema: "uDrive",
                table: "driver");

            migrationBuilder.DropTable(
                name: "Person");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Person",
                schema: "uDrive",
                table: "driver",
                column: "idPerson",
                principalSchema: "uDrive",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Person",
                schema: "uDrive",
                table: "driver");

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
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Person",
                schema: "uDrive",
                table: "driver",
                column: "idPerson",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
