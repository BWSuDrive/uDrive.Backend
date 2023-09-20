using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Model.Configuration;

internal class SpontanesDriveEntityTypeConfiguration
    : EntityTypeConfigurationBase<SpontanesDrive>,
    IEntityTypeConfiguration<SpontanesDrive>
{
    private const string TableSchema = "uDrive";
    private const string Table = "spontanesDrive";

    public void Configure(EntityTypeBuilder<SpontanesDrive> builder)
    {
        // Calls a base class method for default settings
        ConfigureDefaults(builder, Table, TableSchema);
        // Calls method in this class for the entity-specific settings
        ConfigureEntityProperties(builder);
    }

    private static void ConfigureEntityProperties(EntityTypeBuilder<SpontanesDrive> builder)
    {
        //_ = builder.Property(e => e.Id).HasColumnName("id");
        _ = builder.Property(e => e.Date)
            .HasColumnType("datetime")
            .HasColumnName("date");
        _ = builder.Property(e => e.IdDrivingScheduleOverwrite)
            .HasMaxLength(450)
            .HasColumnName("idDrivingScheduleOverwrite");

        _ = builder.HasOne(d => d.IdDrivingScheduleOverwriteNavigation).WithMany(p => p.SpontanesDrives)
            .HasForeignKey(d => d.IdDrivingScheduleOverwrite)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DrivingSchedule_SpontanesDrive");

    }
}
