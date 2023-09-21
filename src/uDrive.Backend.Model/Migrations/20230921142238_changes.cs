using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9abfa5ff-4347-4e81-8cc3-de6c41661432", "60f9d742-6fd6-445e-8c02-055ec70ab9dd" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e17eb711-64b1-4d81-9fa5-87ba617ea84a", "8ee9da42-1303-42be-81d9-aadf42a9d655" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f09273cd-1adf-4a13-b797-267585e68d6d", "af41d9ec-9e71-4a9c-b7ab-443bce642e7e" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fdfd6951-1a19-4dbe-b7eb-9589dc634d62", "dddc8bba-ab43-454c-ba57-0a61f456af7e" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9abfa5ff-4347-4e81-8cc3-de6c41661432");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e17eb711-64b1-4d81-9fa5-87ba617ea84a");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09273cd-1adf-4a13-b797-267585e68d6d");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdfd6951-1a19-4dbe-b7eb-9589dc634d62");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60f9d742-6fd6-445e-8c02-055ec70ab9dd");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ee9da42-1303-42be-81d9-aadf42a9d655");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af41d9ec-9e71-4a9c-b7ab-443bce642e7e");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dddc8bba-ab43-454c-ba57-0a61f456af7e");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "uDrive",
                table: "tourPlan");

            migrationBuilder.RenameColumn(
                name: "Destiniation",
                schema: "uDrive",
                table: "tourPlan",
                newName: "Destination");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Departure",
                schema: "uDrive",
                table: "tourPlan",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                schema: "uDrive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "Secretary", "SECRETARY" },
                    { "7d994773-e6af-42e6-af47-8e9222aa6580", "7d994773-e6af-42e6-af47-8e9222aa6580", "Driver", "DRIVER" },
                    { "895c236c-c6ed-44a4-a882-0085fa06267d", "895c236c-c6ed-44a4-a882-0085fa06267d", "Administrator", "ADMINISTRATOR" },
                    { "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "Person", "PERSON" }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
                values: new object[,]
                {
                    { "0cb501a6-ed9b-46ac-bccb-3a8d14524f67", 0, "24a1c396-5796-41fe-b987-d9609d3850e7", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEMQtu6cOYhIRFfVJVt6+HpHFhnz/4PN5Bpg4MnmBBb0CrVZAcFoAqwWFMl50XiwvLw==", null, false, "fa677514-1a8f-461f-9b11-e973dd4b84f3", false, "Secretary@udrive.de", false },
                    { "4d49563e-cb77-4606-a8cd-353d0f1d6713", 0, "b6afcf93-2a01-4659-84c5-79fdf1d79ffd", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEJ7S/F65oVTPY2Qaa+1uJ5IUWQjt+vmkK8BRPQmz/ihCbuo91JGUtsUQCSSi9uRDlw==", null, false, "104a2737-0738-4c76-a07f-5cce36fd83ac", false, "Person@udrive.de", false },
                    { "834f96e5-f240-4b46-87e5-a679a0f60170", 0, "eb20ce4a-8353-4a1a-8218-23fed3bde10e", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAEKk7A1w+YzlYwDHF6qZsuhXg/oV9ZdM/XBn+nUlnb0atCd8dH0VMmY0GM8pyCggWXw==", null, false, "f1b2586a-8135-4cd8-adf8-b2201ddfe3cc", false, "Driver@udrive.de", false },
                    { "efda5c21-25ae-487f-ae12-a0008f6de339", 0, "0e7dd5be-82ff-488e-ad90-e7c26d336efe", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEOLfCbxuvttyb8PLmnTlivhWJApeztwp4+tf2wGxeTffMTPecOv+jH3DWsH6MyAEcA==", null, false, "5c62adc5-b309-4c85-8cc0-8ff8ff41a8db", false, "Administrator@udrive.de", false }
                });

            migrationBuilder.InsertData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "0cb501a6-ed9b-46ac-bccb-3a8d14524f67" },
                    { "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "4d49563e-cb77-4606-a8cd-353d0f1d6713" },
                    { "7d994773-e6af-42e6-af47-8e9222aa6580", "834f96e5-f240-4b46-87e5-a679a0f60170" },
                    { "895c236c-c6ed-44a4-a882-0085fa06267d", "efda5c21-25ae-487f-ae12-a0008f6de339" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1abb01be-d5c1-4c67-abc5-79dc51516ca8", "0cb501a6-ed9b-46ac-bccb-3a8d14524f67" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9e3b1fb1-2b97-4063-ad9d-3be3c2247898", "4d49563e-cb77-4606-a8cd-353d0f1d6713" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d994773-e6af-42e6-af47-8e9222aa6580", "834f96e5-f240-4b46-87e5-a679a0f60170" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "895c236c-c6ed-44a4-a882-0085fa06267d", "efda5c21-25ae-487f-ae12-a0008f6de339" });

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1abb01be-d5c1-4c67-abc5-79dc51516ca8");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d994773-e6af-42e6-af47-8e9222aa6580");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "895c236c-c6ed-44a4-a882-0085fa06267d");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e3b1fb1-2b97-4063-ad9d-3be3c2247898");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0cb501a6-ed9b-46ac-bccb-3a8d14524f67");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d49563e-cb77-4606-a8cd-353d0f1d6713");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "834f96e5-f240-4b46-87e5-a679a0f60170");

            migrationBuilder.DeleteData(
                schema: "uDrive",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efda5c21-25ae-487f-ae12-a0008f6de339");

            migrationBuilder.DropColumn(
                name: "Verified",
                schema: "uDrive",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Destination",
                schema: "uDrive",
                table: "tourPlan",
                newName: "Destiniation");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Departure",
                schema: "uDrive",
                table: "tourPlan",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "uDrive",
                table: "tourPlan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
