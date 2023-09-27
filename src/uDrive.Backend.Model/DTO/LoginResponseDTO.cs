namespace uDrive.Backend.Model.DTO;

/// <summary>
/// Response DTO after an successful login
/// </summary>
public class LoginResponseDTO : IDTO
{
    /// <summary>
    /// The Id of the <see cref="Entities.Person"/>
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The Username of the <see cref="Entities.Person"/>
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The Firstname of the <see cref="Entities.Person"/>
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// The Lastname of the <see cref="Entities.Person"/>
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// The Email of the <see cref="Entities.Person"/>
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The Token of the <see cref="Entities.Person"/>
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// The Roles of the <see cref="Entities.Person"/>
    /// </summary>
    public List<string> Roles { get; set; }


}
