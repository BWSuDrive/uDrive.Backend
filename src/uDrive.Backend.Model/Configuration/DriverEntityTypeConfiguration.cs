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
        _ = builder.Property(e => e.Id).HasColumnName("id");
        _ = builder.Property(e => e.IdDrivinglicense)
            .HasMaxLength(450)
            .HasColumnName("idDrivinglicense");
        _ = builder.Property(e => e.IdPerson)
            .HasMaxLength(450)
            .HasColumnName("idPerson");

        _ = builder.HasOne(d => d.IdDrivinglicenseNavigation).WithMany(p => p.Drivers)
            .HasForeignKey(d => d.IdDrivinglicense)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Driver_DrivingLicence");

        _ = builder.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Drivers)
            .HasForeignKey(d => d.IdPerson)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Driver_Person");

    }
}
