using MedicalSystem.CoreLayer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalSystem.Api.Services
{
    public class AuthSevice : IAuthService
    {
        public string Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string Register(string username, string password)
        {
            throw new NotImplementedException();
        }
		public dynamic JWTGenerator(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("940713461550-rviiua2vuqdkoumfhjvnts6r2gqgi8sl.apps.googleusercontent.com");

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserName) }),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			//var encrypterToken = tokenHandler.WriteToken(token);

			//SetJWT(encrypterToken);

			//var refreshToken = GenerateRefreshToken();

			//SetRefreshToken(refreshToken, user);

			return new { token = token, username = user.UserName };
		}
		//public void SetJWT(string encrypterToken)
		//{

		//	HttpContext.Response.Cookies.Append("X-Access-Token", encrypterToken,
		//		  new CookieOptions
		//		  {
		//			  Expires = DateTime.Now.AddMinutes(15),
		//			  HttpOnly = true,
		//			  Secure = true,
		//			  IsEssential = true,
		//			  SameSite = SameSiteMode.None
		//		  });
		//}




	}
}
