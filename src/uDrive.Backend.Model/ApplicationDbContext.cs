using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Model
{
    public class ApplicationDbContext : IdentityDbContext<Person, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<DrivingLicence> DrivingLicences { get; set; }
        public virtual DbSet<PassengerRequest> PassengerRequests { get; set; }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<TourPlan> TourPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            _ = modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(EntityTypeConfigurationBase<>).Assembly);

            modelBuilder.AddIdentityConfiguration();

            // only needed for first setup
            modelBuilder.AddRoles();
            modelBuilder.AddUsers();
            modelBuilder.AddUsersToRoles();

        }
    }
}
