using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uDrive.Backend.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                schema: "uDrive",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                schema: "uDrive",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                    table.PrimaryKey("PK_drivingLicence", x => x.id);
                });

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
                    table.PrimaryKey("PK_weekday", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "driver",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idDrivinglicense = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    idPerson = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driver", x => x.id);
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
                name: "drivingSchedule",
                schema: "uDrive",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    start = table.Column<TimeSpan>(type: "time", nullable: false),
                    arrival = table.Column<TimeSpan>(type: "time", nullable: false),
                    idWeekday = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivingSchedule", x => x.id);
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
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    idDrivingScheduleOverwrite = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spontanesDrive", x => x.id);
                    table.ForeignKey(
                        name: "FK_DrivingSchedule_SpontanesDrive",
                        column: x => x.idDrivingScheduleOverwrite,
                        principalSchema: "uDrive",
                        principalTable: "drivingSchedule",
                        principalColumn: "id");
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drivingSchedule_driver",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "spontanesDrive",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "driver",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "drivingSchedule",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "drivingLicence",
                schema: "uDrive");

            migrationBuilder.DropTable(
                name: "weekday",
                schema: "uDrive");

            migrationBuilder.DropColumn(
                name: "Firstname",
                schema: "uDrive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                schema: "uDrive",
                table: "AspNetUsers");
        }
    }
}
