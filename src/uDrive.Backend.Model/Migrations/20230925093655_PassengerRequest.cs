using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class PassengerRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCoordinates",
                schema: "uDrive",
                table: "tourPlan");

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
                    CurrentLongitude = table.Column<double>(type: "float", nullable: false)
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

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "00eada62-edd2-401f-9929-04a3866a53af", "00eada62-edd2-401f-9929-04a3866a53af", "Driver", "DRIVER" },
            //        { "79b2bd5a-161f-4c25-a99c-717875e6ecc4", "79b2bd5a-161f-4c25-a99c-717875e6ecc4", "Administrator", "ADMINISTRATOR" },
            //        { "cb3a358c-8c15-4fb0-956f-07b0286fd566", "cb3a358c-8c15-4fb0-956f-07b0286fd566", "Secretary", "SECRETARY" },
            //        { "efc9d7e3-4817-4c63-95ce-9d64e78d420a", "efc9d7e3-4817-4c63-95ce-9d64e78d420a", "Person", "PERSON" }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Verified" },
            //    values: new object[,]
            //    {
            //        { "0dc0cf8f-0eb0-4d24-8ccc-f116c2960759", 0, "173fbbff-d810-4420-bf8c-64a3a19b27c9", "Driver@udrive.de", true, "Driver", "Driver", false, null, "DRIVER@UDRIVE.DE", "DRIVER@UDRIVE.DE", "AQAAAAIAAYagAAAAENQfBBlsnQVP8ZTFAQ+abMAEl3ZN/h9XNZ5WYcWTcIqtee4vxtsMjhevEpMHQ83Uwg==", null, false, "659d8230-d53f-460f-8055-9395045380b2", false, "Driver@udrive.de", false },
            //        { "62e34523-ee97-4372-8f4e-fb45374c71fd", 0, "7cbb0fb6-ed1c-4326-af4b-82095bf053fa", "Administrator@udrive.de", true, "Administrator", "Administrator", false, null, "ADMINISTRATOR@UDRIVE.DE", "ADMINISTRATOR@UDRIVE.DE", "AQAAAAIAAYagAAAAEBX0XHTIymBQkEXrXERrsG1Ghu4p/oauRO4PM7WkR2K3xDYS3HzqrNoOXpgP/2dcTQ==", null, false, "6091c8e0-ac78-47d0-97db-8447fac9c5d2", false, "Administrator@udrive.de", false },
            //        { "d435fb65-8370-4579-a707-4c9045035dda", 0, "5c6fed2c-6042-4d53-9b67-3272457feeac", "Secretary@udrive.de", true, "Secretary", "Secretary", false, null, "SECRETARY@UDRIVE.DE", "SECRETARY@UDRIVE.DE", "AQAAAAIAAYagAAAAEOKOBZHnk1EBYqHAn6pIsNGcG1IUkj899qLdVm0pORhdJwJOXJu9tiWf8z0k6+y19g==", null, false, "91110878-2fc2-4286-b460-6cf2907d96e8", false, "Secretary@udrive.de", false },
            //        { "f209d3db-dab8-4e63-b015-b7d92a00ce5d", 0, "60728c18-b055-4d3d-8820-bc7679feba1b", "Person@udrive.de", true, "Person", "Person", false, null, "PERSON@UDRIVE.DE", "PERSON@UDRIVE.DE", "AQAAAAIAAYagAAAAEAubVKR3/k76YZshrUK3gb7tKzgM8Ziyd/d6CN8/ikFZV4Gh23konRxjx+8TlwtQpg==", null, false, "bed3cf3f-981e-42db-b933-15350f661df5", false, "Person@udrive.de", false }
            //    });

            //migrationBuilder.InsertData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "00eada62-edd2-401f-9929-04a3866a53af", "0dc0cf8f-0eb0-4d24-8ccc-f116c2960759" },
            //        { "79b2bd5a-161f-4c25-a99c-717875e6ecc4", "62e34523-ee97-4372-8f4e-fb45374c71fd" },
            //        { "cb3a358c-8c15-4fb0-956f-07b0286fd566", "d435fb65-8370-4579-a707-4c9045035dda" },
            //        { "efc9d7e3-4817-4c63-95ce-9d64e78d420a", "f209d3db-dab8-4e63-b015-b7d92a00ce5d" }
            //    });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passengerRequest",
                schema: "uDrive");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "00eada62-edd2-401f-9929-04a3866a53af", "0dc0cf8f-0eb0-4d24-8ccc-f116c2960759" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "79b2bd5a-161f-4c25-a99c-717875e6ecc4", "62e34523-ee97-4372-8f4e-fb45374c71fd" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "cb3a358c-8c15-4fb0-956f-07b0286fd566", "d435fb65-8370-4579-a707-4c9045035dda" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "efc9d7e3-4817-4c63-95ce-9d64e78d420a", "f209d3db-dab8-4e63-b015-b7d92a00ce5d" });

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "00eada62-edd2-401f-9929-04a3866a53af");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "79b2bd5a-161f-4c25-a99c-717875e6ecc4");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "cb3a358c-8c15-4fb0-956f-07b0286fd566");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "efc9d7e3-4817-4c63-95ce-9d64e78d420a");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "0dc0cf8f-0eb0-4d24-8ccc-f116c2960759");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "62e34523-ee97-4372-8f4e-fb45374c71fd");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "d435fb65-8370-4579-a707-4c9045035dda");

            //migrationBuilder.DeleteData(
            //    schema: "uDrive",
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "f209d3db-dab8-4e63-b015-b7d92a00ce5d");

            migrationBuilder.AddColumn<string>(
                name: "CurrentCoordinates",
                schema: "uDrive",
                table: "tourPlan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
