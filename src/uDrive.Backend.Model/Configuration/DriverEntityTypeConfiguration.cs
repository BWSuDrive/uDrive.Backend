using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Model.Configuration;

internal class DriverEntityTypeConfiguration
    : EntityTypeConfigurationBase<Driver>,
    IEntityTypeConfiguration<Driver>
{
    private const string TableSchema = "uDrive";
    private const string Table = "driver";

    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        // Calls a base class method for default settings
        ConfigureDefaults(builder, Table, TableSchema);
        // Calls method in this class for the entity-specific settings
        ConfigureEntityProperties(builder);
    }

    private static void ConfigureEntityProperties(EntityTypeBuilder<Driver> builder)
    {
        //_ = builder.Property(e => e.Id).HasColumnName("id");
        _ = builder.Property(e => e.IdDrivinglicense)
            .HasMaxLength(450)
            .HasColumnName("idDrivinglicense");

        _ = builder.Property(e => e.IdPerson)
            .HasMaxLength(450)
            .HasColumnName("idPerson");

        _ = builder.Property(e => e.Seats).HasColumnName("Seats");

        _ = builder.HasOne(d => d.IdDrivinglicenseNavigation).WithOne(p => p.Driver)
            .HasForeignKey<Driver>(d => d.IdDrivinglicense)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Driver_DrivingLicence");

        _ = builder.HasOne(d => d.IdPersonNavigation).WithOne(p => p.Driver)
            .HasForeignKey<Driver>(d => d.IdPerson)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Driver_Person");

        _ = builder.HasMany(d => d.TourPlans)
                       .WithOne(p => p.Driver)
                       .HasForeignKey(d => d.IdDriver)
                       .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_TourPlan_Driver");

    }
}
