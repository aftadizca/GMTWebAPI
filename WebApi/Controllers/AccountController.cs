using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult GetUser()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return Ok("OK");
            }
            else
            {
                return BadRequest("Login required");
            }
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> PostUserAsync([FromBody] UserModel user)
        {
            var newUser = new IdentityUser(user.Username);
            var test = await _userManager.CreateAsync(newUser, user.Password);
            if (test.Succeeded)
            {
                return CreatedAtAction(nameof(GetUser), new { Id = newUser.Id });
            }
            else
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> SignInAsync([FromBody]UserModel user)
        {
            var test = await _signInManager.PasswordSignInAsync(user.Username, user.Password,false,false);
            if (test.Succeeded)
            {
                var users = await _userManager.FindByNameAsync(user.Username);
                return Ok(new { Username = users.UserName });
            }
            else
            {
                return BadRequest("Wrong Username or Password!!!");
            }
        }

        [HttpGet]
        [Route("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

    }
}