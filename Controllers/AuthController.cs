using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Mappers;
using ShopOnline.API.Models.Auth;
using ShopOnline.API.Services;
using ShopOnline.BLL.interfaces;
using ShopOnline.BLL.Models;
using ShopOnline.DAL.interfaces;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenManager _tokenManager;

        public AuthController(IUserService userService, TokenManager tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromBody] RegisterRequest user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                User? model = user.ToBll(); // DTO → BLL model

                _userService.Register(model);

                return Ok("L'utilisateur a bien été enregistré.");
            }
            catch (ArgumentException ex)
            {
                return Conflict(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = _userService.Login(loginRequest.Email, loginRequest.Password);

                var token = _tokenManager.GenerateJwt(user.Id, user.Username, user.Role);

                return Ok(new { token });
            }
            catch (ArgumentException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }
    }
}