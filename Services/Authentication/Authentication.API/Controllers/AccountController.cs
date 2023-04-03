using Authentication.API.Entities;
using Authentication.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManger;
        //Register
        
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManger)
        {
            _userManager = userManager;
            _signInManger= signInManger;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();

            }

            var user = new User
            {

                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email
            };

            //save the user info to user table
            var result = await _userManager.CreateAsync(user, model.Password);
            if(!result.Errors.Any())
            {
                //user has been successfully created
                return CreatedAtRoute("GetUser", new { controller = "account", id = user.Id });
            }
            return BadRequest(result.Errors.Select(error => error.Description).ToList());

        }




        //Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { error = "please check email/password format" });
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return BadRequest("username does not exist");

            }

            var isAuthenticated = await _userManager.CheckPasswordAsync(user, model.Password);
            if (isAuthenticated)
            {
                return Ok("Username password valid");
            }

            return Unauthorized("username password is invalid");
        
        }


        //GetUserById

    }
}
