using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Services.Interfaces
{
    /// <summary>
    /// Interface for <see cref="AuthService"/>
    /// </summary>
    public interface IAuthService
    {
        /// <inheritdoc />
        Task<bool> AssignPersonToRoleAsync(Person person, string role);
        
        /// <inheritdoc />
        Task<Person> GetLogedInPerson(HttpContext context);
        
        /// <inheritdoc />
        Task<(int identifier, string token, Person? user, List<string>? roles)> LoginAsync(SignInUserDTO model);
        /// <inheritdoc />
        Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials);

        /// <inheritdoc />
        Task<Response<LoginResponseDTO>> RegisterSystemUserAsync(RegisterDTO registerDTO);

        /// <inheritdoc />
        Task<(int identifier, string token, Person? user)> RegistrationAsync(RegisterDTO model);
    }
}
