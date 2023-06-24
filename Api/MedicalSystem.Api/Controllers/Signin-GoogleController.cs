using Google.Apis.Auth;
using MedicalSystem.Api.Services;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigninGoogleController : ControllerBase
    {
		private readonly UserManager<User> _userManager;
		private readonly IAuthService _authService;
		public SigninGoogleController(UserManager<User> userManager,IAuthService authService) 
		{
			_userManager = userManager;
			_authService = authService;
		}
		[HttpPost]
		public async Task <IActionResult> LoginGoogle(SigninDto signinDto)
		{
			var settings = new GoogleJsonWebSignature.ValidationSettings()
			{
				Audience = new List<string>
				{
					"940713461550-rviiua2vuqdkoumfhjvnts6r2gqgi8sl.apps.googleusercontent.com"
				}
			};
			var payload = await GoogleJsonWebSignature.ValidateAsync(signinDto.credential, settings);

			if (payload == null) return BadRequest("Invalid External Authentication");

			var info = new UserLoginInfo("GOOGLE", payload.Subject , "GOOGLE");

			var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
			
			if (user == null)
			{
				user = await _userManager.FindByEmailAsync(payload.Email);
				if (user == null)
				{
					user = new User { Email = payload.Email, UserName = payload.Email };
					await _userManager.CreateAsync(user);
					//prepare and send an email for the email confirmation
					await _userManager.AddToRoleAsync(user, signinDto.role);
					await _userManager.AddLoginAsync(user, info);
				}
				else
				{
					await _userManager.AddLoginAsync(user, info);
				}
			}


			if (user == null)
			{
				return BadRequest("Invalid External Authentication");
			}

			var token = _authService.JWTGenerator(user);
			return Ok(token);
		}

		
	}
}
