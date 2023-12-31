﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uDrive.Backend.Model;

#nullable disable

namespace uDrive.Backend.Model.Migrations
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
                            Id = "bc56875b-72bf-4c07-bc14-b41766715d02",
                            ConcurrencyStamp = "bc56875b-72bf-4c07-bc14-b41766715d02",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "a0523c72-95c5-4c8d-aefd-ab5d51dd91b6",
                            ConcurrencyStamp = "a0523c72-95c5-4c8d-aefd-ab5d51dd91b6",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "b17b4cd4-3c4a-4f89-a7e5-f88405f27dd6",
                            ConcurrencyStamp = "b17b4cd4-3c4a-4f89-a7e5-f88405f27dd6",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "5ab3e8a8-ba3e-44eb-b53f-9a0f82640272",
                            ConcurrencyStamp = "5ab3e8a8-ba3e-44eb-b53f-9a0f82640272",
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
                            UserId = "be002a19-4554-473d-a262-a62b2e75c176",
                            RoleId = "bc56875b-72bf-4c07-bc14-b41766715d02"
                        },
                        new
                        {
                            UserId = "667b8877-92d3-4fca-8ceb-6658714ab9ff",
                            RoleId = "a0523c72-95c5-4c8d-aefd-ab5d51dd91b6"
                        },
                        new
                        {
                            UserId = "db960c2a-dc60-492b-ae56-90c4e2f36f89",
                            RoleId = "b17b4cd4-3c4a-4f89-a7e5-f88405f27dd6"
                        },
                        new
                        {
                            UserId = "691559b0-1394-48e3-a4d7-39270761b625",
                            RoleId = "5ab3e8a8-ba3e-44eb-b53f-9a0f82640272"
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

                    b.HasIndex("IdDrivinglicense")
                        .IsUnique();

                    b.HasIndex("IdPerson")
                        .IsUnique();

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

                    b.Property<string>("IdPerson")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idPerson");

                    b.Property<string>("IdTourPlan")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("idTourPlan");

                    b.Property<bool>("IsDenied")
                        .HasColumnType("bit")
                        .HasColumnName("isDenied");

                    b.Property<bool>("IsPending")
                        .HasColumnType("bit")
                        .HasColumnName("isPending");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("message");

                    b.HasKey("Id")
                        .HasName("PK_uDrive_passengerRequest");

                    b.HasIndex("IdPerson");

                    b.HasIndex("IdTourPlan");

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
                            Id = "be002a19-4554-473d-a262-a62b2e75c176",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "444a0675-674f-461c-906c-2bf3ce860886",
                            Email = "Administrator@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Administrator",
                            Lastname = "Administrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@UDRIVE.DE",
                            NormalizedUserName = "ADMINISTRATOR@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEAAvxwGMm3VbTm6GigbNr8y9kKHAK2vHQrGwbzKtcqHT1EBEfZ4H0fdRyhUNAXI/uQ==",
                            PhoneNumber = "0049619229040",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "0a72d943-f3b4-41cf-9374-b1af61c47afe",
                            TwoFactorEnabled = false,
                            UserName = "Administrator@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "667b8877-92d3-4fca-8ceb-6658714ab9ff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d542d0a6-ef4d-40b4-9208-13c633415c5d",
                            Email = "Secretary@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Secretary",
                            Lastname = "Secretary",
                            LockoutEnabled = false,
                            NormalizedEmail = "SECRETARY@UDRIVE.DE",
                            NormalizedUserName = "SECRETARY@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEAXYx2B5If49Z7eusofWDeH8VyVSlJ1cjauZqgd5tQ1HsJsfpMvYy9TJqssasdoNew==",
                            PhoneNumber = "0049619229040",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "91be4285-5345-43f1-a57d-e0c44da26d06",
                            TwoFactorEnabled = false,
                            UserName = "Secretary@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "db960c2a-dc60-492b-ae56-90c4e2f36f89",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f880e9e2-bb5b-4f74-bb7d-8ab0addf227a",
                            Email = "Driver@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Driver",
                            Lastname = "Driver",
                            LockoutEnabled = false,
                            NormalizedEmail = "DRIVER@UDRIVE.DE",
                            NormalizedUserName = "DRIVER@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEKQAJhmD6C5LSzdb4/7Aq//NZZa9masT63EQrlKpQPFRAAceA+OYZCkp1BpDedlz2w==",
                            PhoneNumber = "0049619229040",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "0f5bea06-8ab0-404b-bc5d-0402ac126f36",
                            TwoFactorEnabled = false,
                            UserName = "Driver@udrive.de",
                            Verified = false
                        },
                        new
                        {
                            Id = "691559b0-1394-48e3-a4d7-39270761b625",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2017e71b-5ee8-4470-9d58-38764205f3b5",
                            Email = "Person@udrive.de",
                            EmailConfirmed = true,
                            Firstname = "Person",
                            Lastname = "Person",
                            LockoutEnabled = false,
                            NormalizedEmail = "PERSON@UDRIVE.DE",
                            NormalizedUserName = "PERSON@UDRIVE.DE",
                            PasswordHash = "AQAAAAIAAYagAAAAEDK7kffCDQj4zJx9nIc2d0Oagf6007Irl5l1HLoICWb2LSVF2JuKl8cjMEcKI18v5g==",
                            PhoneNumber = "0049619229040",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "ac2df993-57e5-4ca4-9b03-c175a747e646",
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
                        .WithOne("Driver")
                        .HasForeignKey("uDrive.Backend.Model.Entities.Driver", "IdDrivinglicense")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_DrivingLicence");

                    b.HasOne("uDrive.Backend.Model.Entities.Person", "IdPersonNavigation")
                        .WithOne("Driver")
                        .HasForeignKey("uDrive.Backend.Model.Entities.Driver", "IdPerson")
                        .IsRequired()
                        .HasConstraintName("FK_Driver_Person");

                    b.Navigation("IdDrivinglicenseNavigation");

                    b.Navigation("IdPersonNavigation");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.PassengerRequest", b =>
                {
                    b.HasOne("uDrive.Backend.Model.Entities.Person", "Person")
                        .WithMany("PassengerRequests")
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Person_PassengarRequests");

                    b.HasOne("uDrive.Backend.Model.Entities.TourPlan", "TourPlan")
                        .WithMany("PassengerRequests")
                        .HasForeignKey("IdTourPlan")
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
                    b.Navigation("Driver");
                });

            modelBuilder.Entity("uDrive.Backend.Model.Entities.Person", b =>
                {
                    b.Navigation("Driver");

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
