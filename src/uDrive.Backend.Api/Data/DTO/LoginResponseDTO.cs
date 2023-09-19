namespace uDrive.Backend.Api.Data.DTO;

public class LoginResponseDTO : IDTO
{
  public string Id { get; set; }
    public string UserName { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    
}
