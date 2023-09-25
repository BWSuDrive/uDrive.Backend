using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class extendDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drivingSchedule_driver",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "spontanesDrive",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "drivingSchedule",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "weekday",
                schema: "uDrive");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "4e2c9736-1ded-49ef-a213-a917f07ab285", "431294cb-0e1e-4393-ae6f-18a20001d433" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "7833f63a-cee2-408b-83c5-27b574110bb8", "7e99b87f-225f-41c6-9fa6-af56ae9bb44c" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "84ec3b8a-7e9d-4270-992c-2afdb84e3cf4", "80fd3e25-6bce-4b35-9bc8-e8c1bd592e48" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "a7aa55f2-d822-4124-954f-29a0212347ac", "dad80396-7f18-4938-a7c9-35f510bb611f" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "4e2c9736-1ded-49ef-a213-a917f07ab285");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "7833f63a-cee2-408b-83c5-27b574110bb8");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "84ec3b8a-7e9d-4270-992c-2afdb84e3cf4");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "a7aa55f2-d822-4124-954f-29a0212347ac");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "431294cb-0e1e-4393-ae6f-18a20001d433");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "7e99b87f-225f-41c6-9fa6-af56ae9bb44c");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "80fd3e25-6bce-4b35-9bc8-e8c1bd592e48");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "dad80396-7f18-4938-a7c9-35f510bb611f");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                schema: "uDrive",
                table: "driver",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "129a8b16-2384-4fd5-ba38-9bc1dc8d0f59", "129a8b16-2384-4fd5-ba38-9bc1dc8d0f59", "Driver", "DRIVER" },
            //        { "14ee1067-e6ca-45bc-931c-794842eaf4b1", "14ee1067-e6ca-45bc-931c-794842eaf4b1", "Secretary", "SECRETARY" },
            //        { "39569ca1-d0a8-43ba-a108-01f7ca14d59b", "39569ca1-d0a8-43ba-a108-01f7ca14d59b", "Person", "PERSON" },
            //        { "e26f7233-6ebc-496e-b2b2-0297780616cf", "e26f7233-6ebc-496e-b2b2-0297780616cf", "Administrator", "ADMINISTRATOR" }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
            //    values: new object[,]
            //    {
            //        { "583eab94-0fab-4f6f-b1f6-5b5373392ea1", 0, "cd899b33-f424-43e0-a3f6-351a60a20d2d", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEHxeSJ70O7Lqgh3yBzN7k4AWEYsZp90FL4ETHJ3axaJPRbI5WJEA9LOPoIN9A0lbXA==", null, false, "37246fb8-fb5f-4172-9171-e02a6345ee97", false, "Driver@udrive.de", false },
            //        { "65ff54ef-d26c-4136-b34d-fe196111d739", 0, "54a78820-c15f-455e-968d-1744d8cf1e70", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAENdRalFZ/6FUNnDO97cDSgB0ZUmGusc+QNEbKOagTjjd9pBecapm5mHBnE7ApzdZZQ==", null, false, "b9d95649-ad55-4991-92c7-29c0eac37f79", false, "Secretary@udrive.de", false },
            //        { "7c596c7b-7e18-4591-9e9f-eccc8ad27d3e", 0, "7b79d8b4-dc93-49a4-9dc5-6f913c2bbd35", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEE6umwXsQu6Wn+H6zWfrDJIlWdkh8Gg2ecOcuzsFs2INcCRJoTM8b4gQy9NuGCx6cg==", null, false, "a68214f7-9f5f-4816-9780-24d2c7bc1021", false, "Person@udrive.de", false },
            //        { "fd333960-7858-4fff-b401-2547e961e599", 0, "4f56b834-678a-4874-ab77-b4bb1a8ef44a", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEMYNTmZxDXEa9DT2M5N6hUFNojHugZjo7CE57U1ccTfc417jl42vwAU6JQ1XPEhVsw==", null, false, "64287bbf-ecee-4178-a9cf-e39ada57ca44", false, "Administrator@udrive.de", false }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "129a8b16-2384-4fd5-ba38-9bc1dc8d0f59", "583eab94-0fab-4f6f-b1f6-5b5373392ea1" },
            //        { "14ee1067-e6ca-45bc-931c-794842eaf4b1", "65ff54ef-d26c-4136-b34d-fe196111d739" },
            //        { "39569ca1-d0a8-43ba-a108-01f7ca14d59b", "7c596c7b-7e18-4591-9e9f-eccc8ad27d3e" },
            //        { "e26f7233-6ebc-496e-b2b2-0297780616cf", "fd333960-7858-4fff-b401-2547e961e599" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_PersonTourPlan_PassengersId",
                schema: "uDrive",
                table: "PersonTourPlan",
                column: "PassengersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTourPlan",
                schema: "uDrive");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "129a8b16-2384-4fd5-ba38-9bc1dc8d0f59", "583eab94-0fab-4f6f-b1f6-5b5373392ea1" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "14ee1067-e6ca-45bc-931c-794842eaf4b1", "65ff54ef-d26c-4136-b34d-fe196111d739" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "39569ca1-d0a8-43ba-a108-01f7ca14d59b", "7c596c7b-7e18-4591-9e9f-eccc8ad27d3e" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "e26f7233-6ebc-496e-b2b2-0297780616cf", "fd333960-7858-4fff-b401-2547e961e599" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "129a8b16-2384-4fd5-ba38-9bc1dc8d0f59");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "14ee1067-e6ca-45bc-931c-794842eaf4b1");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "39569ca1-d0a8-43ba-a108-01f7ca14d59b");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "e26f7233-6ebc-496e-b2b2-0297780616cf");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "583eab94-0fab-4f6f-b1f6-5b5373392ea1");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "65ff54ef-d26c-4136-b34d-fe196111d739");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "7c596c7b-7e18-4591-9e9f-eccc8ad27d3e");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "fd333960-7858-4fff-b401-2547e961e599");

            migrationBuilder.DropColumn(
                name: "Seats",
                schema: "uDrive",
                table: "driver");

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
                name: "drivingSchedule",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idWeekday = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    arrival = table.Column<TimeSpan>(type: "time", nullable: false),
                    start = table.Column<TimeSpan>(type: "time", nullable: false)
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
                    idDrivingScheduleOverwrite = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true)
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

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "4e2c9736-1ded-49ef-a213-a917f07ab285", "4e2c9736-1ded-49ef-a213-a917f07ab285", "Secretary", "SECRETARY" },
            //        { "7833f63a-cee2-408b-83c5-27b574110bb8", "7833f63a-cee2-408b-83c5-27b574110bb8", "Driver", "DRIVER" },
            //        { "84ec3b8a-7e9d-4270-992c-2afdb84e3cf4", "84ec3b8a-7e9d-4270-992c-2afdb84e3cf4", "Administrator", "ADMINISTRATOR" },
            //        { "a7aa55f2-d822-4124-954f-29a0212347ac", "a7aa55f2-d822-4124-954f-29a0212347ac", "Person", "PERSON" }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
            //    values: new object[,]
            //    {
            //        { "431294cb-0e1e-4393-ae6f-18a20001d433", 0, "8e3e0d66-9782-4ac5-b396-23010d9107a5", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEOR50/rAAXcxIuHEuaCaG/zh4hzNZSjn7i2/G1I1PUmKOFFwQupBz4xUzG1GOQtCJQ==", null, false, "ff4bf770-5032-4932-8b05-f591f6727ad0", false, "Secretary@udrive.de", false },
            //        { "7e99b87f-225f-41c6-9fa6-af56ae9bb44c", 0, "4518d1dc-90b8-4269-8ce3-040ed60fed0e", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEPpPI1PA0rGX+Ip+fZbE/Ut5/IaW7p0lHV/SkL4C/SB/aJbi6ob+8DG4vunxNIY7GQ==", null, false, "0a1e55ef-7e1b-44ad-aca3-1cbaf41da793", false, "Driver@udrive.de", false },
            //        { "80fd3e25-6bce-4b35-9bc8-e8c1bd592e48", 0, "d8e2e064-ee87-4ed3-81d4-5128e5de83e1", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAECnzNeFluiSO0ppY+01XDL0SeILJTW4iMMltggkuBvy5AoSlmEZvKpx4XMwvqPYUXw==", null, false, "2a1aacd7-a557-4221-a56a-881707b62df7", false, "Administrator@udrive.de", false },
            //        { "dad80396-7f18-4938-a7c9-35f510bb611f", 0, "1d5654db-560c-4798-81b8-cae31db64628", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEAIUCWR0ZNXEHGq/5DlbiFRo5HiVZT/n8h/DAU78XtQza3+JwCDu+NATH+E7ucOJjA==", null, false, "bfefd301-d221-4ccb-b28f-88816e2d50f6", false, "Person@udrive.de", false }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "4e2c9736-1ded-49ef-a213-a917f07ab285", "431294cb-0e1e-4393-ae6f-18a20001d433" },
            //        { "7833f63a-cee2-408b-83c5-27b574110bb8", "7e99b87f-225f-41c6-9fa6-af56ae9bb44c" },
            //        { "84ec3b8a-7e9d-4270-992c-2afdb84e3cf4", "80fd3e25-6bce-4b35-9bc8-e8c1bd592e48" },
            //        { "a7aa55f2-d822-4124-954f-29a0212347ac", "dad80396-7f18-4938-a7c9-35f510bb611f" }
            //    });

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
        }
    }
}
