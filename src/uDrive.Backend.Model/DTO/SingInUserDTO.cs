namespace uDrive.Backend.Model.DTO;

/// <summary>
/// The DTO for an Login Request
/// </summary>
public class SignInUserDTO : IDTO
{
    /// <summary>
    /// The UserName
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The Password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The Email
    /// </summary>
    public string Email { get; set; }
}
