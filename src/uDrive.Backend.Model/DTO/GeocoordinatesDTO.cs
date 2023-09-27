namespace uDrive.Backend.Model.DTO;

/// <summary>
/// DTO to send Coordinates to the API
/// </summary>
public class GeocoordinatesDTO
{
    /// <summary>
    /// The current Latitude
    /// </summary>
    public double CurrentLatitude { get; set; }

    /// <summary>
    /// The current Longitude
    /// </summary>
    public double CurrentLongitude { get; set; }
}
