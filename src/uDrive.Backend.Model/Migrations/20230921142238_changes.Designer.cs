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
    [Migration("20230921142238_changes")]
    partial class changes
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
                            Id = "895c236c-c6ed-44a4-a882-0085fa06267d",
                            ConcurrencyStamp = "895c236c-c6ed-44a4-a882-0085fa06267d",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "1abb01be-d5c1-4c67-abc5-79dc51516ca8",
                            ConcurrencyStamp = "1abb01be-d5c1-4c67-abc5-79dc51516ca8",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "7d994773-e6af-42e6-af47-8e9222aa6580",
                            ConcurrencyStamp = "7d994773-e6af-42e6-af47-8e9222aa6580",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "9e3b1fb1-2b97-4063-ad9d-3be3c2247898",
                            ConcurrencyStamp = "9e3b1fb1-2b97-4063-ad9d-3be3c2247898",
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
                            UserId = "efda5c21-25ae-487f-ae12-a0008f6de339",
                            RoleId = "895c236c-c6ed-44a4-a882-0085fa06267d"
                        },
                        new
                        {
                            UserId = "0cb501a6-ed9b-46ac-bccb-3a8d14524f67",
                            RoleId = "1abb01be-d5c1-4c67-abc5-79dc51516ca8"
                        },
                        new
                        {
                            UserId = "834f96e5-f240-4b46-87e5-a679a0f60170",
                            RoleId = "7d994773-e6af-42e6-af47-8e9222aa6580"
                        },
                        new
                        {
                            UserId = "4d49563e-cb77-4606-a8cd-353d0f1d6713",
                            RoleId = "9e3b1fb1-2b97-4063-ad9d-3be3c2247898"
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

                    b.Property<bool>("Verified")
                        .HasColumnType("bit");

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
                            Id = "efda5c21-25ae-487f-ae12-a0008f6de339",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0e7dd5be-82ff-488e-ad90-e7c26d336efe",
                            Email = "Administrator@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Administrator",
                            Lastname = "Administrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@UDRIVE.DE",
                            NormalizedUserName = "ADMINISTRATOR@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEOLfCbxuvttyb8PLmnTlivhWJApeztwp4+tf2wGxeTffMTPecOv+jH3DWsH6MyAEcA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5c62adc5-b309-4c85-8cc0-8ff8ff41a8db",
                            TwoFactorEnabled = false,
                            UserName = "Administrator@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "0cb501a6-ed9b-46ac-bccb-3a8d14524f67",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "24a1c396-5796-41fe-b987-d9609d3850e7",
                            Email = "Secretary@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Secretary",
                            Lastname = "Secretary",
                            LockoutEnabled = false,
                            NormalizedEmail = "SECRETARY@UDRIVE.DE",
                            NormalizedUserName = "SECRETARY@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEMQtu6cOYhIRFfVJVt6+HpHFhnz/4PN5Bpg4MnmBBb0CrVZAcFoAqwWFMl50XiwvLw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fa677514-1a8f-461f-9b11-e973dd4b84f3",
                            TwoFactorEnabled = false,
                            UserName = "Secretary@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "834f96e5-f240-4b46-87e5-a679a0f60170",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eb20ce4a-8353-4a1a-8218-23fed3bde10e",
                            Email = "Driver@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Driver",
                            Lastname = "Driver",
                            LockoutEnabled = false,
                            NormalizedEmail = "DRIVER@UDRIVE.DE",
                            NormalizedUserName = "DRIVER@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEKk7A1w+YzlYwDHF6qZsuhXg/oV9ZdM/XBn+nUlnb0atCd8dH0VMmY0GM8pyCggWXw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f1b2586a-8135-4cd8-adf8-b2201ddfe3cc",
                            TwoFactorEnabled = false,
                            UserName = "Driver@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "4d49563e-cb77-4606-a8cd-353d0f1d6713",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b6afcf93-2a01-4659-84c5-79fdf1d79ffd",
                            Email = "Person@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Person",
                            Lastname = "Person",
                            LockoutEnabled = false,
                            NormalizedEmail = "PERSON@UDRIVE.DE",
                            NormalizedUserName = "PERSON@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEJ7S/F65oVTPY2Qaa+1uJ5IUWQjt+vmkK8BRPQmz/ihCbuo91JGUtsUQCSSi9uRDlw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "104a2737-0738-4c76-a07f-5cce36fd83ac",
                            TwoFactorEnabled = false,
                            UserName = "Person@udrive.de",
                            Verified = false
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

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime");

                    b.Property<string>("Destination")
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