using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using uDrive.Backend.Api.Data.Models;
using System.Reflection.Emit;

namespace uDrive.Backend.Api.Data.Configuration;

internal class WeekdayEntityTypeConfiguration
    : EntityTypeConfigurationBase<Weekday>,
    IEntityTypeConfiguration<Weekday>
{
    private const string TableSchema = "uDrive";
    private const string Table = "weekday";

    public void Configure(EntityTypeBuilder<Weekday> builder)
    {
        // Calls a base class method for default settings
        ConfigureDefaults(builder, Table, TableSchema);
        // Calls method in this class for the entity-specific settings
        ConfigureEntityProperties(builder);
    }

    private static void ConfigureEntityProperties(EntityTypeBuilder<Weekday> builder)
    {
        _ = builder.Property(e => e.Id).HasColumnName("id");
        _ = builder.Property(e => e.Name)
            .HasMaxLength(20)
            .HasColumnName("name");

    }
}
