﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uDrive.Backend.Api.Data;

#nullable disable

namespace uDrive.Backend.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = "554eb2b3-bb72-4b98-906c-961a2df7c598",
                            ConcurrencyStamp = "554eb2b3-bb72-4b98-906c-961a2df7c598",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "18c3884c-2091-4944-b0cd-5ebf17092458",
                            ConcurrencyStamp = "18c3884c-2091-4944-b0cd-5ebf17092458",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf",
                            ConcurrencyStamp = "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "d2eab8f6-d599-4fe9-9d77-18fa45a20068",
                            ConcurrencyStamp = "d2eab8f6-d599-4fe9-9d77-18fa45a20068",
                            Name = "Person",
                            NormalizedName = "PERSON"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "2c498d17-4ec6-40b5-93b2-56e83e5498e2",
                            RoleId = "554eb2b3-bb72-4b98-906c-961a2df7c598"
                        },
                        new
                        {
                            UserId = "29c18bb9-34ec-4f0b-aff7-50f8d78ea4cc",
                            RoleId = "18c3884c-2091-4944-b0cd-5ebf17092458"
                        },
                        new
                        {
                            UserId = "f5f7ce85-b383-4368-a969-af31e28463a1",
                            RoleId = "a0c00a8e-2dec-41db-8b19-761a4aa1eeaf"
                        },
                        new
                        {
                            UserId = "da58ee98-8702-4bde-99e7-07ddfb413c46",
                            RoleId = "d2eab8f6-d599-4fe9-9d77-18fa45a20068"
                        });
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

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.Driver", b =>
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

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.DrivingLicence", b =>
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

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.DrivingSchedule", b =>
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

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.Person", b =>
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

                    b.HasData(
                        new
                        {
                            Id = "2c498d17-4ec6-40b5-93b2-56e83e5498e2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2ac10161-c31f-4987-9920-c5bfa35672cf",
                            Email = "Administrator@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Administrator",
                            Lastname = "Administrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@UDRIVE.DE",
                            NormalizedUserName = "ADMINISTRATOR@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEDP5JkgtHOdNTiOTz+fCwA1nERS1gKL++MWeIqmYHHfiIHTQS3u32Zj3M5d5U3n+Hg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c1bd93ac-e43e-48de-9743-81dd6441927a",
                            TwoFactorEnabled = false,
                            UserName = "Administrator@udrive.de"
                        },
                        new
                        {
                            Id = "29c18bb9-34ec-4f0b-aff7-50f8d78ea4cc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2b047410-c562-4400-8766-f5a317025938",
                            Email = "Secretary@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Secretary",
                            Lastname = "Secretary",
                            LockoutEnabled = false,
                            NormalizedEmail = "SECRETARY@UDRIVE.DE",
                            NormalizedUserName = "SECRETARY@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEMGF68CpO17D8oko+hnjZUXFcZGjRiNhB5m26AoBxJ1XprtdZ1n4V1BtKl3LRcIAWA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1280b489-0940-4bad-83e0-421c6cc6f5ec",
                            TwoFactorEnabled = false,
                            UserName = "Secretary@udrive.de"
                        },
                        new
                        {
                            Id = "f5f7ce85-b383-4368-a969-af31e28463a1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "45922ec3-c79f-43fd-9da1-adfc13faa883",
                            Email = "Driver@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Driver",
                            Lastname = "Driver",
                            LockoutEnabled = false,
                            NormalizedEmail = "DRIVER@UDRIVE.DE",
                            NormalizedUserName = "DRIVER@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAECBNUNl8oEQ998f+kW4qbiqWBxCbQmS1nOaxt8/wKKp2dI+ReGmQlzKBTcmN1tlM4A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "744f0586-48c2-4989-89df-ca3b77c9db66",
                            TwoFactorEnabled = false,
                            UserName = "Driver@udrive.de"
                        },
                        new
                        {
                            Id = "da58ee98-8702-4bde-99e7-07ddfb413c46",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3c3d5b1b-77ab-4ec9-96a6-87c89271e7e3",
                            Email = "Person@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Person",
                            Lastname = "Person",
                            LockoutEnabled = false,
                            NormalizedEmail = "PERSON@UDRIVE.DE",
                            NormalizedUserName = "PERSON@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEAMfTuaqiY57m/TvuANyJHUqwtCeTcN+Fp8D+zsZQGInjELOd20q8ZazW2Lhzw6gPQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "986c7bfa-00f6-4496-92f0-10e0e20ad51c",
                            TwoFactorEnabled = false,
                            UserName = "Person@udrive.de"
                        });
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.SpontanesDrive", b =>
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

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.Weekday", b =>
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
                    b.HasOne("uDrive.Backend.Api.Data.Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .IsRequired()
                        .HasConstraintName("FK__drivingSc__drive__08B54D69");

                    b.HasOne("uDrive.Backend.Api.Data.Models.DrivingSchedule", null)
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
                    b.HasOne("uDrive.Backend.Api.Data.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Data.Models.Person", null)
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

                    b.HasOne("uDrive.Backend.Api.Data.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Data.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.Driver", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Data.Models.DrivingLicence", "IdDrivinglicenseNavigation")
                        .WithMany("Drivers")
                        .HasForeignKey("IdDrivinglicense")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_DrivingLicence");

                    b.HasOne("uDrive.Backend.Api.Data.Models.Person", "IdPersonNavigation")
                        .WithMany("Drivers")
                        .HasForeignKey("IdPerson")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_Person");

                    b.Navigation("IdDrivinglicenseNavigation");

                    b.Navigation("IdPersonNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.DrivingSchedule", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Data.Models.Weekday", "IdWeekdayNavigation")
                        .WithMany("DrivingSchedules")
                        .HasForeignKey("IdWeekday")
                        .IsRequired()
                        .HasConstraintName("FK_Weekday_DrivingSchedule");

                    b.Navigation("IdWeekdayNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.SpontanesDrive", b =>
                {
                    b.HasOne("uDrive.Backend.Api.Data.Models.DrivingSchedule", "IdDrivingScheduleOverwriteNavigation")
                        .WithMany("SpontanesDrives")
                        .HasForeignKey("IdDrivingScheduleOverwrite")
                        .IsRequired()
                        .HasConstraintName("FK_DrivingSchedule_SpontanesDrive");

                    b.Navigation("IdDrivingScheduleOverwriteNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.DrivingLicence", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.DrivingSchedule", b =>
                {
                    b.Navigation("SpontanesDrives");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.Person", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("uDrive.Backend.Api.Data.Models.Weekday", b =>
                {
                    b.Navigation("DrivingSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
