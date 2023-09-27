namespace uDrive.Backend.Model.DTO;

/// <summary>
/// The DTO for an registration, heritages <see cref="SignInUserDTO"/>
/// </summary>
public class RegisterDTO : SignInUserDTO
{
    /// <summary>
    /// The selected new Firstname
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// The selected new Lastname
    /// </summary>
    public string Lastname { get; set; }


    /// <summary>
    /// The PhoneNumber
    /// </summary>
    public string PhoneNumber { get; set; }

}
