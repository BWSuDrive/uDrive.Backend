﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uDrive.Backend.Api.Data;

#nullable disable

namespace uDrive.Backend.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230912214851_UpdatePerson")]
    partial class UpdatePerson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DrivingScheduleDriver", b =>
                {
                    b.Property<string>("DrivingScheduleId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("drivingSchedule_id");

                    b.Property<string>("DriverId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("driver_id");

                    b.HasKey("DrivingScheduleId", "DriverId")
                        .HasName("PK__drivingS__1748636A316DE11E");

                    b.HasIndex("DriverId");

                    b.ToTable("drivingSchedule_driver", "uDrive");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", "uDrive");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "uDrive");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "uDrive");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "uDrive");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "uDrive");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.Driver", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("IdDrivinglicense")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idDrivinglicense");

                    b.Property<string>("IdPerson")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idPerson");

                    b.HasKey("Id");

                    b.HasIndex("IdDrivinglicense");

                    b.HasIndex("IdPerson");

                    b.ToTable("driver", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.DrivingLicence", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("expireDate");

                    b.Property<string>("LicenceClass")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("licenceClass");

                    b.HasKey("Id");

                    b.ToTable("drivingLicence", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.DrivingSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<TimeSpan>("Arrival")
                        .HasColumnType("time")
                        .HasColumnName("arrival");

                    b.Property<string>("IdWeekday")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idWeekday");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time")
                        .HasColumnName("start");

                    b.HasKey("Id");

                    b.HasIndex("IdWeekday");

                    b.ToTable("drivingSchedule", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.Person", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.SpontanesDrive", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("IdDrivingScheduleOverwrite")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idDrivingScheduleOverwrite");

                    b.HasKey("Id");

                    b.HasIndex("IdDrivingScheduleOverwrite");

                    b.ToTable("spontanesDrive", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.Weekday", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("weekday", "uDrive");
                });

            modelBuilder.Entity("DrivingScheduleDriver", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .IsRequired()
                        .HasConstraintName("FK__drivingSc__drive__08B54D69");

                    b.HasOne("uDrive.Backend.Api.Models.DrivingSchedule", null)
                        .WithMany()
                        .HasForeignKey("DrivingScheduleId")
                        .IsRequired()
                        .HasConstraintName("FK__drivingSc__drivi__07C12930");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uDrive.Backend.Api.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.Driver", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Models.DrivingLicence", "IdDrivinglicenseNavigation")
                        .WithMany("Drivers")
                        .HasForeignKey("IdDrivinglicense")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_DrivingLicence");

                    b.HasOne("uDrive.Backend.Api.Models.Person", "IdPersonNavigation")
                        .WithMany("Drivers")
                        .HasForeignKey("IdPerson")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_Person");

                    b.Navigation("IdDrivinglicenseNavigation");

                    b.Navigation("IdPersonNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.DrivingSchedule", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Models.Weekday", "IdWeekdayNavigation")
                        .WithMany("DrivingSchedules")
                        .HasForeignKey("IdWeekday")
                        .IsRequired()
                        .HasConstraintName("FK_Weekday_DrivingSchedule");

                    b.Navigation("IdWeekdayNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.SpontanesDrive", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Models.DrivingSchedule", "IdDrivingScheduleOverwriteNavigation")
                        .WithMany("SpontanesDrives")
                        .HasForeignKey("IdDrivingScheduleOverwrite")
                        .IsRequired()
                        .HasConstraintName("FK_DrivingSchedule_SpontanesDrive");

                    b.Navigation("IdDrivingScheduleOverwriteNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.DrivingLicence", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.DrivingSchedule", b =>
                {
                    b.Navigation("SpontanesDrives");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.Person", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Models.Weekday", b =>
                {
                    b.Navigation("DrivingSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}