using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Login : ControllerBase
    {
        private readonly SignInManager<Person> _signInManager;
        private readonly ILogger<Login> _logger;
        private readonly UserManager<Person> _userManager;
        private readonly IConfiguration _configuration;

        public Login(SignInManager<Person> signInManager, UserManager<Person> userManager, ILogger<Login> logger, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(SignInUserDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var verifyUser = await _userManager.FindByEmailAsync(login.Email).ConfigureAwait(false);
            if (verifyUser is null)
            {
                return BadRequest("Wrong Email or Password");
            }

            var loginUser = await _signInManager.PasswordSignInAsync(verifyUser, login.Password, false, true).ConfigureAwait(false);
            if (loginUser is null)
            {
                return BadRequest("Login failed ");

            }
            var token = await GenerateJWTTokenAsync(verifyUser).ConfigureAwait(false);
            var createResponse = new Response<LoginResponseDTO>()
            {
                Success = true,
                Message = "Login succeded",
                Data = new LoginResponseDTO()
                { Email = login.Email, Firstname = verifyUser.Firstname, Lastname = verifyUser.Lastname, Id = verifyUser.Id, UserName = verifyUser.UserName, Token = token }

            };
            return Ok(createResponse);
        }

        private async Task<string> GenerateJWTTokenAsync(Person person)
        {
            var roles = await _userManager.GetRolesAsync(person).ConfigureAwait(false);
            var role = roles.FirstOrDefault();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, person.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, role)
        };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
