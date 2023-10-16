using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Entities;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private ILogger<AuthController> logger;

        public AuthController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            ILogger<AuthController> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                User identityUser = new User()
                {
                    UserName = userModel.UserName,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email
                };

                IdentityResult result = await userManager.CreateAsync(identityUser, userModel.Password);

                if (result.Succeeded)
                {
                    return Ok(identityUser);
                }

                return Ok("Failed to register");
            }
            catch(Exception ex) {
                logger.LogError(ex.Message);
                return BadRequest();
            }
            
        }
    }
}
