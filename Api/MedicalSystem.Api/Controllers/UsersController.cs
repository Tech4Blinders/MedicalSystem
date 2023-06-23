using MedicalSystem.Api.Services.AuthService;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _auth;

        public UsersController(IAuthService auth)
        {
            _auth = auth;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            var result = await _auth.LoginAsync(dto);
            if (result.Message == "User not found")
            {
                return NotFound(result.Message);
            }
            else if (result.Message == "Password is wrong")
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
