using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public Login(SignInManager<Person> signInManager, UserManager<Person> userManager, ILogger<Login> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(SignInUserDTO login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var verifyUser = await _userManager.FindByEmailAsync(login.Email).ConfigureAwait(false);
            if(verifyUser is null)
            {
                return BadRequest("Wrong Email or PAssword");
            }

            var loginUser = await _signInManager.PasswordSignInAsync(verifyUser, login.Password,false,true).ConfigureAwait(false);
            if(loginUser is null)
            {
                return BadRequest("Login failed ");

            }
            return Ok(login);
        }
    }
}
