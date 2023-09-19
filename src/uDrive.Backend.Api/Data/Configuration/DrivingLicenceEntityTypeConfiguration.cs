using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using uDrive.Backend.Api.Data.Models;
using System.Reflection.Emit;

namespace uDrive.Backend.Api.Data.Configuration;

internal class DrivingLicenceEntityTypeConfiguration
    : EntityTypeConfigurationBase<DrivingLicence>,
    IEntityTypeConfiguration<DrivingLicence>
{
    private const string TableSchema = "uDrive";
    private const string Table = "drivingLicence";

    public void Configure(EntityTypeBuilder<DrivingLicence> builder)
    {
        // Calls a base class method for default settings
        ConfigureDefaults(builder, Table, TableSchema);
        // Calls method in this class for the entity-specific settings
        ConfigureEntityProperties(builder);
    }

    private static void ConfigureEntityProperties(EntityTypeBuilder<DrivingLicence> builder)
    {
        _ = builder.Property(e => e.Id).HasColumnName("id");
        _ = builder.Property(e => e.ExpireDate).HasColumnName("expireDate");
        _ = builder.Property(e => e.LicenceClass)
            .HasMaxLength(20)
            .HasColumnName("licenceClass");

    }
}
