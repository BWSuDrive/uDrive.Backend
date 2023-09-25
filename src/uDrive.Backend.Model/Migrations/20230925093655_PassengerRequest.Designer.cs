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
    [Migration("20230925093655_PassengerRequest")]
    partial class PassengerRequest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Id = "79b2bd5a-161f-4c25-a99c-717875e6ecc4",
                            ConcurrencyStamp = "79b2bd5a-161f-4c25-a99c-717875e6ecc4",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "cb3a358c-8c15-4fb0-956f-07b0286fd566",
                            ConcurrencyStamp = "cb3a358c-8c15-4fb0-956f-07b0286fd566",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "00eada62-edd2-401f-9929-04a3866a53af",
                            ConcurrencyStamp = "00eada62-edd2-401f-9929-04a3866a53af",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "efc9d7e3-4817-4c63-95ce-9d64e78d420a",
                            ConcurrencyStamp = "efc9d7e3-4817-4c63-95ce-9d64e78d420a",
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
                            UserId = "62e34523-ee97-4372-8f4e-fb45374c71fd",
                            RoleId = "79b2bd5a-161f-4c25-a99c-717875e6ecc4"
                        },
                        new
                        {
                            UserId = "d435fb65-8370-4579-a707-4c9045035dda",
                            RoleId = "cb3a358c-8c15-4fb0-956f-07b0286fd566"
                        },
                        new
                        {
                            UserId = "0dc0cf8f-0eb0-4d24-8ccc-f116c2960759",
                            RoleId = "00eada62-edd2-401f-9929-04a3866a53af"
                        },
                        new
                        {
                            UserId = "f209d3db-dab8-4e63-b015-b7d92a00ce5d",
                            RoleId = "efc9d7e3-4817-4c63-95ce-9d64e78d420a"
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

            modelBuilder.Entity("PersonTourPlan", b =>
                {
                    b.Property<string>("AsPassengersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PassengersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AsPassengersId", "PassengersId");

                    b.HasIndex("PassengersId");

                    b.ToTable("PersonTourPlan", "uDrive");
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

                    b.Property<int>("Seats")
                        .HasColumnType("int")
                        .HasColumnName("Seats");

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

            modelBuilder.Entity("uDrive.Backend.Model.Entities.PassengerRequest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<double>("CurrentLatitude")
                        .HasColumnType("float");

                    b.Property<double>("CurrentLongitude")
                        .HasColumnType("float");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("message");

                    b.Property<string>("idPerson")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idPerson");

                    b.Property<string>("idTourPlan")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idTourPlan");

                    b.HasKey("Id")
                        .HasName("PK_uDrive_passengerRequest");

                    b.HasIndex("idPerson");

                    b.HasIndex("idTourPlan");

                    b.ToTable("passengerRequest", "uDrive");
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
                            Id = "62e34523-ee97-4372-8f4e-fb45374c71fd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7cbb0fb6-ed1c-4326-af4b-82095bf053fa",
                            Email = "Administrator@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Administrator",
                            Lastname = "Administrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@UDRIVE.DE",
                            NormalizedUserName = "ADMINISTRATOR@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEBX0XHTIymBQkEXrXERrsG1Ghu4p/oauRO4PM7WkR2K3xDYS3HzqrNoOXpgP/2dcTQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6091c8e0-ac78-47d0-97db-8447fac9c5d2",
                            TwoFactorEnabled = false,
                            UserName = "Administrator@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "d435fb65-8370-4579-a707-4c9045035dda",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5c6fed2c-6042-4d53-9b67-3272457feeac",
                            Email = "Secretary@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Secretary",
                            Lastname = "Secretary",
                            LockoutEnabled = false,
                            NormalizedEmail = "SECRETARY@UDRIVE.DE",
                            NormalizedUserName = "SECRETARY@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEOKOBZHnk1EBYqHAn6pIsNGcG1IUkj899qLdVm0pORhdJwJOXJu9tiWf8z0k6+y19g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "91110878-2fc2-4286-b460-6cf2907d96e8",
                            TwoFactorEnabled = false,
                            UserName = "Secretary@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "0dc0cf8f-0eb0-4d24-8ccc-f116c2960759",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "173fbbff-d810-4420-bf8c-64a3a19b27c9",
                            Email = "Driver@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Driver",
                            Lastname = "Driver",
                            LockoutEnabled = false,
                            NormalizedEmail = "DRIVER@UDRIVE.DE",
                            NormalizedUserName = "DRIVER@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAENQfBBlsnQVP8ZTFAQ+abMAEl3ZN/h9XNZ5WYcWTcIqtee4vxtsMjhevEpMHQ83Uwg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "659d8230-d53f-460f-8055-9395045380b2",
                            TwoFactorEnabled = false,
                            UserName = "Driver@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "f209d3db-dab8-4e63-b015-b7d92a00ce5d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "60728c18-b055-4d3d-8820-bc7679feba1b",
                            Email = "Person@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Person",
                            Lastname = "Person",
                            LockoutEnabled = false,
                            NormalizedEmail = "PERSON@UDRIVE.DE",
                            NormalizedUserName = "PERSON@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEAubVKR3/k76YZshrUK3gb7tKzgM8Ziyd/d6CN8/ikFZV4Gh23konRxjx+8TlwtQpg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bed3cf3f-981e-42db-b933-15350f661df5",
                            TwoFactorEnabled = false,
                            UserName = "Person@udrive.de",
                            Verified = false
                        });
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.TourPlan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<double>("CurrentLatitude")
                        .HasColumnType("float");

                    b.Property<double>("CurrentLongitude")
                        .HasColumnType("float");

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

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StopRequests")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_uDrive_tourPlan");

                    b.HasIndex("IdDriver");

                    b.ToTable("tourPlan", "uDrive");
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

            modelBuilder.Entity("PersonTourPlan", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.TourPlan", null)
                        .WithMany()
                        .HasForeignKey("AsPassengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uDrive.Backend.Model.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PassengersId")
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

            modelBuilder.Entity("uDrive.Backend.Model.Entities.PassengerRequest", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.Person", "Person")
                        .WithMany("PassengerRequests")
                        .HasForeignKey("idPerson")
                        .IsRequired()
                        .HasConstraintName("FK_Person_PassengarRequests");

                    b.HasOne("uDrive.Backend.Model.Entities.TourPlan", "TourPlan")
                        .WithMany("PassengerRequests")
                        .HasForeignKey("idTourPlan")
                        .IsRequired()
                        .HasConstraintName("FK_TourPlan_PassengarRequests");

                    b.Navigation("Person");

                    b.Navigation("TourPlan");
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

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Person", b =>
                {
                    b.Navigation("Drivers");

                    b.Navigation("PassengerRequests");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.TourPlan", b =>
                {
                    b.Navigation("PassengerRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
