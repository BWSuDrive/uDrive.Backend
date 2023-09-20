using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weekday_DrivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule");

            migrationBuilder.DropTable(
                name: "Weekday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_weekday",
                schema: "uDrive",
                table: "weekday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tourPlan",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spontanesDrive",
                schema: "uDrive",
                table: "spontanesDrive");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drivingLicence",
                schema: "uDrive",
                table: "drivingLicence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_driver",
                schema: "uDrive",
                table: "driver");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_uDrive_weekday",
                schema: "uDrive",
                table: "weekday",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uDrive_tourPlan",
                schema: "uDrive",
                table: "tourPlan",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uDrive_spontanesDrive",
                schema: "uDrive",
                table: "spontanesDrive",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uDrive_drivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uDrive_drivingLicence",
                schema: "uDrive",
                table: "drivingLicence",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uDrive_driver",
                schema: "uDrive",
                table: "driver",
                column: "id");

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19cc144b-e160-497f-821e-dc15829a0dbb", "19cc144b-e160-497f-821e-dc15829a0dbb", "Secretary", "SECRETARY" },
                    { "5d908f91-94eb-4878-8fd5-566464fea1ea", "5d908f91-94eb-4878-8fd5-566464fea1ea", "Driver", "DRIVER" },
                    { "ee973fd6-e00b-4358-9d8a-03d7d6bb3b9d", "ee973fd6-e00b-4358-9d8a-03d7d6bb3b9d", "Person", "PERSON" },
                    { "f41f0407-3fc7-4c6e-918c-589ff2001b9c", "f41f0407-3fc7-4c6e-918c-589ff2001b9c", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "08d19afb-f1ed-4a7d-9f20-c436b402dc4f", 0, "6dbd035f-317a-46f2-afc1-4715b9042d46", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEEghsj0HogfArl3ytTodeCc6Cr59j17yVRJR397rrBh8evb5gKGoId9D8z+iY1JT2Q==", null, false, "d8d7c8de-2679-4b41-b7c6-00174955a7cd", false, "Person@udrive.de" },
                    { "6beac474-53f6-4869-8c11-2e6608ea084a", 0, "5999945e-4a9c-42c1-913f-9e2614613e64", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEJycBN9a+DfofSTnwQBLOtoA4DaQ1sD4JbkY1Z501CaizdDzFjSZ4AfekIQAtY7IqQ==", null, false, "5126467c-084c-4013-a828-a9056057e020", false, "Administrator@udrive.de" },
                    { "a8792986-2c8c-4ea2-9b71-68f2d53231aa", 0, "5b4208c5-4878-4167-be1e-079a6f451e5f", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEAoze7xfhYwmxAjr5LKtCu1WpRzOQ32RcGtw3kPDNBtCGh1O4OIPJnOrvSbdsvq2bA==", null, false, "0b4274a4-9651-4560-8ccb-3f84e1762570", false, "Secretary@udrive.de" },
                    { "c37ba379-acf8-41e1-b4ac-e4ba44a8b59a", 0, "21faef0e-5e85-438f-8141-4afd39c411e0", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAECKodUPtuhYYUhYj4/Gp0nRs/lwiKeugusop/pv8SpKOIw2ivZCn3gvf2C587TfM4Q==", null, false, "342a16ef-8f0d-4cbb-b28f-efe4378d402d", false, "Driver@udrive.de" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ee973fd6-e00b-4358-9d8a-03d7d6bb3b9d", "08d19afb-f1ed-4a7d-9f20-c436b402dc4f" },
                    { "f41f0407-3fc7-4c6e-918c-589ff2001b9c", "6beac474-53f6-4869-8c11-2e6608ea084a" },
                    { "19cc144b-e160-497f-821e-dc15829a0dbb", "a8792986-2c8c-4ea2-9b71-68f2d53231aa" },
                    { "5d908f91-94eb-4878-8fd5-566464fea1ea", "c37ba379-acf8-41e1-b4ac-e4ba44a8b59a" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Weekday_DrivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule",
                column: "idWeekday",
                principalSchema: "uDrive",
                principalTable: "weekday",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPlan_Driver",
                schema: "uDrive",
                table: "tourPlan",
                column: "IdDriver",
                principalSchema: "uDrive",
                principalTable: "driver",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weekday_DrivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPlan_Driver",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uDrive_weekday",
                schema: "uDrive",
                table: "weekday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uDrive_tourPlan",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uDrive_spontanesDrive",
                schema: "uDrive",
                table: "spontanesDrive");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uDrive_drivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uDrive_drivingLicence",
                schema: "uDrive",
                table: "drivingLicence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uDrive_driver",
                schema: "uDrive",
                table: "driver");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee973fd6-e00b-4358-9d8a-03d7d6bb3b9d", "08d19afb-f1ed-4a7d-9f20-c436b402dc4f" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f41f0407-3fc7-4c6e-918c-589ff2001b9c", "6beac474-53f6-4869-8c11-2e6608ea084a" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "19cc144b-e160-497f-821e-dc15829a0dbb", "a8792986-2c8c-4ea2-9b71-68f2d53231aa" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d908f91-94eb-4878-8fd5-566464fea1ea", "c37ba379-acf8-41e1-b4ac-e4ba44a8b59a" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19cc144b-e160-497f-821e-dc15829a0dbb");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d908f91-94eb-4878-8fd5-566464fea1ea");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee973fd6-e00b-4358-9d8a-03d7d6bb3b9d");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f41f0407-3fc7-4c6e-918c-589ff2001b9c");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08d19afb-f1ed-4a7d-9f20-c436b402dc4f");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6beac474-53f6-4869-8c11-2e6608ea084a");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8792986-2c8c-4ea2-9b71-68f2d53231aa");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c37ba379-acf8-41e1-b4ac-e4ba44a8b59a");

            migrationBuilder.AddPrimaryKey(
                name: "PK_weekday",
                schema: "uDrive",
                table: "weekday",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tourPlan",
                schema: "uDrive",
                table: "tourPlan",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spontanesDrive",
                schema: "uDrive",
                table: "spontanesDrive",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drivingLicence",
                schema: "uDrive",
                table: "drivingLicence",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_driver",
                schema: "uDrive",
                table: "driver",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Weekday",
                columns: table => new
                {
                    TempId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_Weekday_TempId1", x => x.TempId1);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Weekday_DrivingSchedule",
                schema: "uDrive",
                table: "drivingSchedule",
                column: "idWeekday",
                principalTable: "Weekday",
                principalColumn: "TempId1");
        }
    }
}
