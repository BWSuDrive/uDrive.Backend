namespace uDrive.Backend.Model.DTO;

public class SignInUserDTO : IDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
