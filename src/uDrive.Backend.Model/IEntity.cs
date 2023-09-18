namespace uDrive.Backend.Model;

/// <summary>
/// Represents a database entity with the key <see cref="Id"/>.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Key, which is generated on the database side.
    /// </summary>
    string Id { get; internal set; }
}
