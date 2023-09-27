namespace uDrive.Backend.Model.Entities;

public class DrivingLicence : IEntity
{
    /// <inheritdoc />
    public string? Id { get; set; }

    /// <summary>
    /// Expiration Date of the <see cref="DrivingLicence"/>
    /// </summary>
    public DateTime ExpireDate { get; set; }


    /// <summary>
    /// Classification of the <see cref="DrivingLicence"/>
    /// </summary>
    public string LicenceClass { get; set; } = null!;

    /// <summary>
    /// Related <see cref="Entities.Driver"/> Entity
    /// </summary>
    public virtual Driver? Driver { get; } = default;
}
