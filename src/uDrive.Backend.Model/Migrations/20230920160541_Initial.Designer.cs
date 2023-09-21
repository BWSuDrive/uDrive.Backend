﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uDrive.Backend.Model;

#nullable disable

namespace uDrive.Backend.Model.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230920160541_Initial")]
    partial class Initial
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

                    b.HasData(
                        new
                        {
                            Id = "fdfd6951-1a19-4dbe-b7eb-9589dc634d62",
                            ConcurrencyStamp = "fdfd6951-1a19-4dbe-b7eb-9589dc634d62",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "e17eb711-64b1-4d81-9fa5-87ba617ea84a",
                            ConcurrencyStamp = "e17eb711-64b1-4d81-9fa5-87ba617ea84a",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "f09273cd-1adf-4a13-b797-267585e68d6d",
                            ConcurrencyStamp = "f09273cd-1adf-4a13-b797-267585e68d6d",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "9abfa5ff-4347-4e81-8cc3-de6c41661432",
                            ConcurrencyStamp = "9abfa5ff-4347-4e81-8cc3-de6c41661432",
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
                            UserId = "dddc8bba-ab43-454c-ba57-0a61f456af7e",
                            RoleId = "fdfd6951-1a19-4dbe-b7eb-9589dc634d62"
                        },
                        new
                        {
                            UserId = "8ee9da42-1303-42be-81d9-aadf42a9d655",
                            RoleId = "e17eb711-64b1-4d81-9fa5-87ba617ea84a"
                        },
                        new
                        {
                            UserId = "af41d9ec-9e71-4a9c-b7ab-443bce642e7e",
                            RoleId = "f09273cd-1adf-4a13-b797-267585e68d6d"
                        },
                        new
                        {
                            UserId = "60f9d742-6fd6-445e-8c02-055ec70ab9dd",
                            RoleId = "9abfa5ff-4347-4e81-8cc3-de6c41661432"
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

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Driver", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Id")
                        .HasName("PK_uDrive_driver");

                    b.HasIndex("IdDrivinglicense");

                    b.HasIndex("IdPerson");

                    b.ToTable("driver", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.DrivingLicence", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Id")
                        .HasName("PK_uDrive_drivingLicence");

                    b.ToTable("drivingLicence", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.DrivingSchedule", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Id")
                        .HasName("PK_uDrive_drivingSchedule");

                    b.HasIndex("IdWeekday");

                    b.ToTable("drivingSchedule", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Person", b =>
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
                            Id = "dddc8bba-ab43-454c-ba57-0a61f456af7e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7cd5d28e-1e8a-4b91-bac1-3f4e2befddd9",
                            Email = "Administrator@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Administrator",
                            Lastname = "Administrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@UDRIVE.DE",
                            NormalizedUserName = "ADMINISTRATOR@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEOI36ZnPQZEzzAIe5gQzr9zAuEOjv4uigPbjfRTungnM3y9r5MoNhIvFT1217gOcPQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8b7684fe-98d6-4fb6-bbde-9162dc2b9d07",
                            TwoFactorEnabled = false,
                            UserName = "Administrator@udrive.de"
                        },
                        new
                        {
                            Id = "8ee9da42-1303-42be-81d9-aadf42a9d655",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "acadca04-ad7a-446a-878c-f79bfc561571",
                            Email = "Secretary@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Secretary",
                            Lastname = "Secretary",
                            LockoutEnabled = false,
                            NormalizedEmail = "SECRETARY@UDRIVE.DE",
                            NormalizedUserName = "SECRETARY@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEKRFmxvxYmdMAkofPJfiQOHBKfCEdk4DIjIbGu5CEAlawx8hlLT0BkuD+6PEVM3AIA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d8c54738-c0a5-4e44-a5eb-0ff1b56feaa7",
                            TwoFactorEnabled = false,
                            UserName = "Secretary@udrive.de"
                        },
                        new
                        {
                            Id = "af41d9ec-9e71-4a9c-b7ab-443bce642e7e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5825af23-28a7-4405-87e7-199184598e7b",
                            Email = "Driver@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Driver",
                            Lastname = "Driver",
                            LockoutEnabled = false,
                            NormalizedEmail = "DRIVER@UDRIVE.DE",
                            NormalizedUserName = "DRIVER@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEPi3rOvpBZl6AnW+Bi8BWaC10Lu+N7D4e5qgXFMmth0KeWxyPJ//AQpLI+TmhH19nA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "52625683-3f82-4c02-99d5-99ab6ed48aff",
                            TwoFactorEnabled = false,
                            UserName = "Driver@udrive.de"
                        },
                        new
                        {
                            Id = "60f9d742-6fd6-445e-8c02-055ec70ab9dd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e9b59417-9016-4d8f-8e32-e03113c45255",
                            Email = "Person@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Person",
                            Lastname = "Person",
                            LockoutEnabled = false,
                            NormalizedEmail = "PERSON@UDRIVE.DE",
                            NormalizedUserName = "PERSON@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEJWTrHSpKCI14MIRY+fAEL1cZgslctjPu8D2O/t7+KFmIxEg2AJPj5plCyFtlZSDgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0dead13b-cd93-4b07-b87d-d4bd7381d374",
                            TwoFactorEnabled = false,
                            UserName = "Person@udrive.de"
                        });
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.SpontanesDrive", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Id")
                        .HasName("PK_uDrive_spontanesDrive");

                    b.HasIndex("IdDrivingScheduleOverwrite");

                    b.ToTable("spontanesDrive", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.TourPlan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Departure")
                        .HasColumnType("time");

                    b.Property<string>("Destiniation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Eta")
                        .HasColumnType("time");

                    b.Property<string>("IdDriver")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IdDriver");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StopRequests")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_uDrive_tourPlan");

                    b.HasIndex("IdDriver");

                    b.ToTable("tourPlan", "uDrive");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Weekday", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK_uDrive_weekday");

                    b.ToTable("weekday", "uDrive");
                });

            modelBuilder.Entity("DrivingScheduleDriver", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .IsRequired()
                        .HasConstraintName("FK__drivingSc__drive__08B54D69");

                    b.HasOne("uDrive.Backend.Model.Entities.DrivingSchedule", null)
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
                    b.HasOne("uDrive.Backend.Model.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.Person", null)
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

                    b.HasOne("uDrive.Backend.Model.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Driver", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.DrivingLicence", "IdDrivinglicenseNavigation")
                        .WithMany("Drivers")
                        .HasForeignKey("IdDrivinglicense")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_DrivingLicence");

                    b.HasOne("uDrive.Backend.Model.Entities.Person", "IdPersonNavigation")
                        .WithMany("Drivers")
                        .HasForeignKey("IdPerson")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_Person");

                    b.Navigation("IdDrivinglicenseNavigation");

                    b.Navigation("IdPersonNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.DrivingSchedule", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.Weekday", "IdWeekdayNavigation")
                        .WithMany("DrivingSchedules")
                        .HasForeignKey("IdWeekday")
                        .IsRequired()
                        .HasConstraintName("FK_Weekday_DrivingSchedule");

                    b.Navigation("IdWeekdayNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.SpontanesDrive", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.DrivingSchedule", "IdDrivingScheduleOverwriteNavigation")
                        .WithMany("SpontanesDrives")
                        .HasForeignKey("IdDrivingScheduleOverwrite")
                        .IsRequired()
                        .HasConstraintName("FK_DrivingSchedule_SpontanesDrive");

                    b.Navigation("IdDrivingScheduleOverwriteNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.TourPlan", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.Driver", "Driver")
                        .WithMany("TourPlans")
                        .HasForeignKey("IdDriver")
                        .IsRequired()
                        .HasConstraintName("FK_TourPlan_Driver");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Driver", b =>
                {
                    b.Navigation("TourPlans");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.DrivingLicence", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.DrivingSchedule", b =>
                {
                    b.Navigation("SpontanesDrives");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Person", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Weekday", b =>
                {
                    b.Navigation("DrivingSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}