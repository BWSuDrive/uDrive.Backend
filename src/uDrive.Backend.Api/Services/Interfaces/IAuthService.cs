using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Api.Data.DTO;

namespace uDrive.Backend.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials);
    }
}
