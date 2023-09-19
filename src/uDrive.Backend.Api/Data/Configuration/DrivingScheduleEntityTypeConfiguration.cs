using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using uDrive.Backend.Api.Data.Models;
using System.Reflection.Emit;

namespace uDrive.Backend.Api.Data.Configuration;

internal class DrivingScheduleEntityTypeConfiguration
    : EntityTypeConfigurationBase<DrivingSchedule>,
    IEntityTypeConfiguration<DrivingSchedule>
{
    private const string TableSchema = "uDrive";
    private const string Table = "drivingSchedule";

    public void Configure(EntityTypeBuilder<DrivingSchedule> builder)
    {
        // Calls a base class method for default settings
        ConfigureDefaults(builder, Table, TableSchema);
        // Calls method in this class for the entity-specific settings
        ConfigureEntityProperties(builder);
    }

    private static void ConfigureEntityProperties(EntityTypeBuilder<DrivingSchedule> builder)
    {
        _ = builder.Property(e => e.Id).HasColumnName("id");
        _ = builder.Property(e => e.Arrival).HasColumnName("arrival");
        _ = builder.Property(e => e.IdWeekday)
            .HasMaxLength(450)
            .HasColumnName("idWeekday");
        _ = builder.Property(e => e.Start).HasColumnName("start");

        _ = builder.HasOne(d => d.IdWeekdayNavigation).WithMany(p => p.DrivingSchedules)
            .HasForeignKey(d => d.IdWeekday)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Weekday_DrivingSchedule");

        _ = builder.HasMany(d => d.Drivers).WithMany(p => p.DrivingSchedules)
            .UsingEntity<Dictionary<string, object>>(
                "DrivingScheduleDriver",
                r => r.HasOne<Driver>().WithMany()
                    .HasForeignKey("DriverId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__drivingSc__drive__08B54D69"),
                l => l.HasOne<DrivingSchedule>().WithMany()
                    .HasForeignKey("DrivingScheduleId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__drivingSc__drivi__07C12930"),
                j =>
                {
                    _ = j.HasKey("DrivingScheduleId", "DriverId").HasName("PK__drivingS__1748636A316DE11E");
                    _ = j.ToTable("drivingSchedule_driver", "uDrive");
                    _ = j.IndexerProperty<string>("DrivingScheduleId").HasColumnName("drivingSchedule_id");
                    _ = j.IndexerProperty<string>("DriverId").HasColumnName("driver_id");
                });

    }
}
