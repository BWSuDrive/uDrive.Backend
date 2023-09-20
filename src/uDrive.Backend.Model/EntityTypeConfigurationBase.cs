using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace uDrive.Backend.Model;


/// <summary>
/// Base class for entity type configurations
/// </summary>
/// <remarks>
/// Entity type configurations configure entity classes for
/// the database context.
/// We only read from views.
/// Updates, Inserts and Deletes are done by stored procedures,
/// that's why we need mapping settings for stored procedures.
/// Settings common to all entity classes are performed in this
/// base class.
/// </remarks>
/// <typeparam name="T">Entity class this configuration is for</typeparam>
public abstract class EntityTypeConfigurationBase<T>
    where T : class, IEntity
{
    protected static void ConfigureDefaults(
        EntityTypeBuilder<T> builder,
        string table,
        string tableSchema
    )
    {
        builder.ToTable(table, tableSchema);
        ConfigurePKColumn(builder, table, tableSchema);

    }

    protected static void ConfigurePKColumn(
       EntityTypeBuilder<T> builder,
       string table,
       string schema
   )
    {
        _ = builder.HasKey(x => x.Id).HasName($"PK_{schema}_{table}");
        _ = builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();

      
    }

}
