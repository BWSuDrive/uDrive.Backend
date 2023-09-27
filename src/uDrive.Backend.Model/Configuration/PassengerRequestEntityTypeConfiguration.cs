using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Model.Configuration;

internal class PassengerRequestEntityTypeConfiguration
    : EntityTypeConfigurationBase<PassengerRequest>,
    IEntityTypeConfiguration<PassengerRequest>
{
    private const string TableSchema = "uDrive";
    private const string Table = "passengerRequest";

    public void Configure(EntityTypeBuilder<PassengerRequest> builder)
    {
        // Calls a base class method for default settings
        ConfigureDefaults(builder, Table, TableSchema);
        // Calls method in this class for the entity-specific settings
        ConfigureEntityProperties(builder);
    }

    private static void ConfigureEntityProperties(EntityTypeBuilder<PassengerRequest> builder)
    {
        //_ = builder.Property(e => e.Id).HasColumnName("id");
        _ = builder.Property(e => e.IdTourPlan)
            .HasMaxLength(450)
            .HasColumnName("idTourPlan");

        _ = builder.Property(e => e.IdPerson)
            .HasMaxLength(450)
            .HasColumnName("idPerson");

        _ = builder.Property(e => e.Message).HasColumnName("message");

        _ = builder.Property(e => e.IsPending).HasColumnName("isPending");

        _ = builder.Property(e => e.IsDenied).HasColumnName("isDenied");

        _ = builder.HasOne(d => d.Person).WithMany(p => p.PassengerRequests)
            .HasForeignKey(d => d.IdPerson)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Person_PassengarRequests");

        _ = builder.HasOne(d => d.TourPlan).WithMany(p => p.PassengerRequests)
            .HasForeignKey(d => d.IdTourPlan)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_TourPlan_PassengarRequests");

    }
}
