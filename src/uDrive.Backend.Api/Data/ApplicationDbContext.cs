using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using uDrive.Backend.Api.Data.Models;

namespace uDrive.Backend.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<DrivingLicence> DrivingLicences { get; set; }

        public virtual DbSet<DrivingSchedule> DrivingSchedules { get; set; }
        public virtual DbSet<Person> Persons { get; set; }


        public virtual DbSet<SpontanesDrive> SpontanesDrives { get; set; }

        public virtual DbSet<Weekday> Weekdays { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            _ = modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(EntityTypeConfigurationBase<>).Assembly);

            modelBuilder.AddIdentityConfiguration();
            modelBuilder.AddRoles();
            modelBuilder.AddUsers();
            modelBuilder.AddUsersToRoles();

        }
    }
}
