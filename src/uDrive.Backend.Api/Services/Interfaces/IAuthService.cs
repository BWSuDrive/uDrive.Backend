using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Services.Interfaces
{
    public interface IAuthService
    {
        //Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials);
        Task<(int, string, Person?)> Login(SignInUserDTO model);
        Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials);
    }
}
