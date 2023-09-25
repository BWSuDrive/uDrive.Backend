using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AssignPersonToRoleAsync(Person person, string role);
        Task<Person> GetLogedInPerson(HttpContext context);

        //Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials);
        Task<(int identifier, string token, Person? user, List<string>? roles)> LoginAsync(SignInUserDTO model);
        Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials);
        Task<Response<LoginResponseDTO>> RegisterSystemUserAsync(RegisterDTO registerDTO);
        Task<(int identifier, string token, Person? user, List<string>? roles)> RegistrationAsync(RegisterDTO model);
    }
}
