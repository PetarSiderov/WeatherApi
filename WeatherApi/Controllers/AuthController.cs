using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Entities;
using WeatherApi.Helpers;
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
                    return Ok(new { data = "User is created" });
                }

                return Ok("Failed to register");
            }
            catch(Exception ex) {
                logger.LogError($"{ex.Message}");
                return BadRequest();
            }
            
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(LoginModel user)
        {
            try
            {
                User userFound = await userManager.FindByNameAsync(user.username);
                if(userFound == null)
                {
                    return Ok("Wrong credentials");
                }

                var signInResult = await signInManager.CheckPasswordSignInAsync(userFound, user.password,false);

                if(signInResult.Succeeded)
                {
                    return Ok(new { token = AuthHelper.GenerateToken(userFound) });
                }

                return Ok("Wrong credentials");
            }
            catch(Exception ex)
            {
                logger.LogError($"{ex.Message}");
                return BadRequest();
            }
        }
    }
}
