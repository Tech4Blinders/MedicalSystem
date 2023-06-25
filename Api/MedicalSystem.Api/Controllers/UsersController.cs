using MedicalSystem.Api.Services.AuthService;
using MedicalSystem.Api.Services.UploadImage;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IUploadImg upload_img ;

        public UsersController(IAuthService auth, IUploadImg _upload)
        {
            _auth = auth;
            upload_img = _upload;
        }

        

        [HttpPost]
        [Route("Login")]
        [Authorize]
        public async Task<ActionResult<string>> LoginAsync(LoginDto dto)
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
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromForm] RegisterDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.File != null || dto.File.Length != 0)
            {
                dto.Image = upload_img.uploadImg(dto.File.FileName, dto.File.OpenReadStream());
            }

           

            var result = await _auth.RegisterAsync(dto);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);

        }
    }
}
