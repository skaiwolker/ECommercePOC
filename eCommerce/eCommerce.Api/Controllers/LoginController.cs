using eCommerce.Domain.DTOs;
using eCommerce.Domain.Models;
using eCommerce.Services.Exceptions;
using eCommerce.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = await _userService.Login(loginDTO);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var token = _userService.GenerateToken(claimIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                return Ok(token);
            }
            catch (eCommerceException ex)
            {
                return StatusCode(Convert.ToInt32(ex.StatusCode), new
                {
                    eCommerceEx = ex.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    exception = e.Message
                });
            }
        }

        [HttpGet("infos")]
        public async Task<ActionResult<UserDTO>> GetLoggedUserInfo()
        {
            try {

                string email = "";

                if (String.IsNullOrEmpty(HttpContext.User.FindFirst(ClaimTypes.Email).Value))
                {
                    email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                }

                var user = await _userService.GetInfos(email);
                return Ok(user);
            }
            catch (eCommerceException ex)
            {
                return StatusCode(Convert.ToInt32(ex.StatusCode), new
                {
                    eCommerceEx = ex.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    exception = e.Message
                });
            }
        }

    }
}
