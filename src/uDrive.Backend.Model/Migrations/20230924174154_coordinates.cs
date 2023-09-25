using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class coordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "0cb501a6-ed9b-46ac-bccb-3a8d14524f67" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "4d49563e-cb77-4606-a8cd-353d0f1d6713" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "7d994773-e6af-42e6-af47-8e9222aa6580", "834f96e5-f240-4b46-87e5-a679a0f60170" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "895c236c-c6ed-44a4-a882-0085fa06267d", "efda5c21-25ae-487f-ae12-a0008f6de339" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "1abb01be-d5c1-4c67-abc5-79dc51516ca8");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "7d994773-e6af-42e6-af47-8e9222aa6580");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "895c236c-c6ed-44a4-a882-0085fa06267d");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "9e3b1fb1-2b97-4063-ad9d-3be3c2247898");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "0cb501a6-ed9b-46ac-bccb-3a8d14524f67");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "4d49563e-cb77-4606-a8cd-353d0f1d6713");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "834f96e5-f240-4b46-87e5-a679a0f60170");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "efda5c21-25ae-487f-ae12-a0008f6de339");

            migrationBuilder.AlterColumn<int>(
                name: "StopRequests",
                schema: "uDrive",
                table: "tourPlan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CurrentCoordinates",
                schema: "uDrive",
                table: "tourPlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CurrentLatitude",
                schema: "uDrive",
                table: "tourPlan",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentLongitude",
                schema: "uDrive",
                table: "tourPlan",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                schema: "uDrive",
                table: "tourPlan",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "CurrentCoordinates",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.DropColumn(
                name: "CurrentLatitude",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.DropColumn(
                name: "CurrentLongitude",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.DropColumn(
                name: "Message",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.AlterColumn<int>(
                name: "StopRequests",
                schema: "uDrive",
                table: "tourPlan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "Secretary", "SECRETARY" },
            //        { "7d994773-e6af-42e6-af47-8e9222aa6580", "7d994773-e6af-42e6-af47-8e9222aa6580", "Driver", "DRIVER" },
            //        { "895c236c-c6ed-44a4-a882-0085fa06267d", "895c236c-c6ed-44a4-a882-0085fa06267d", "Administrator", "ADMINISTRATOR" },
            //        { "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "Person", "PERSON" }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
            //    values: new object[,]
            //    {
            //        { "0cb501a6-ed9b-46ac-bccb-3a8d14524f67", 0, "24a1c396-5796-41fe-b987-d9609d3850e7", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEMQtu6cOYhIRFfVJVt6+HpHFhnz/4PN5Bpg4MnmBBb0CrVZAcFoAqwWFMl50XiwvLw==", null, false, "fa677514-1a8f-461f-9b11-e973dd4b84f3", false, "Secretary@udrive.de", false },
            //        { "4d49563e-cb77-4606-a8cd-353d0f1d6713", 0, "b6afcf93-2a01-4659-84c5-79fdf1d79ffd", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEJ7S/F65oVTPY2Qaa+1uJ5IUWQjt+vmkK8BRPQmz/ihCbuo91JGUtsUQCSSi9uRDlw==", null, false, "104a2737-0738-4c76-a07f-5cce36fd83ac", false, "Person@udrive.de", false },
            //        { "834f96e5-f240-4b46-87e5-a679a0f60170", 0, "eb20ce4a-8353-4a1a-8218-23fed3bde10e", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEKk7A1w+YzlYwDHF6qZsuhXg/oV9ZdM/XBn+nUlnb0atCd8dH0VMmY0GM8pyCggWXw==", null, false, "f1b2586a-8135-4cd8-adf8-b2201ddfe3cc", false, "Driver@udrive.de", false },
            //        { "efda5c21-25ae-487f-ae12-a0008f6de339", 0, "0e7dd5be-82ff-488e-ad90-e7c26d336efe", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEOLfCbxuvttyb8PLmnTlivhWJApeztwp4+tf2wGxeTffMTPecOv+jH3DWsH6MyAEcA==", null, false, "5c62adc5-b309-4c85-8cc0-8ff8ff41a8db", false, "Administrator@udrive.de", false }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "0cb501a6-ed9b-46ac-bccb-3a8d14524f67" },
            //        { "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "4d49563e-cb77-4606-a8cd-353d0f1d6713" },
            //        { "7d994773-e6af-42e6-af47-8e9222aa6580", "834f96e5-f240-4b46-87e5-a679a0f60170" },
            //        { "895c236c-c6ed-44a4-a882-0085fa06267d", "efda5c21-25ae-487f-ae12-a0008f6de339" }
            //    });
        }
    }
}
