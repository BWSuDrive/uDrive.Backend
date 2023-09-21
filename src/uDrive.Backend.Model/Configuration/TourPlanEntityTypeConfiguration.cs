using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Model.Configuration;

internal class TourPlanEntityTypeConfiguration
    : EntityTypeConfigurationBase<TourPlan>,
    IEntityTypeConfiguration<TourPlan>
{
    private const string TableSchema = "uDrive";
    private const string Table = "tourPlan";

    public void Configure(EntityTypeBuilder<TourPlan> builder)
    {
        // Calls a base class method for default settings
        ConfigureDefaults(builder, Table, TableSchema);
        // Calls method in this class for the entity-specific settings
        ConfigureEntityProperties(builder);
    }

    private static void ConfigureEntityProperties(EntityTypeBuilder<TourPlan> builder)
    {
        //_ = builder.Property(e => e.Id).HasColumnName("id");

        _ = builder.Property(e => e.IdDriver)
          .HasMaxLength(450)
          .HasColumnName("IdDriver");

        _ = builder.Property<string>(e => e.Destination)
            .IsRequired()
            .HasColumnType("nvarchar(max)");


        _ = builder.Property<TimeSpan>(e => e.Eta )
            .HasColumnType("time");


        _ = builder.Property<string>(e => e.Start)
            .IsRequired()
            .HasColumnType("nvarchar(max)");

        _ = builder.Property<int>(e => e.StopRequests)
            .HasColumnType("int");

        _ = builder.Property<DateTime>(e => e.Departure)
            .HasColumnType("datetime");

       

        _ = builder.HasOne(d => d.Driver)
                       .WithMany(p => p.TourPlans)
                       .HasForeignKey(d => d.IdDriver)
                       .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_TourPlan_Driver");
    }
}
