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
using AutoMapper;
using CloudinaryDotNet.Actions;
using MedicalSystem.Api.Services.AuthService;
using MedicalSystem.Api.Services.Helper;
using MedicalSystem.BusinessLayer;
using MedicalSystem.BusinessLayer.Managers.IdentityDtos;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalSystem.Api;

public class AuthSevice : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly Jwt _jwt;

    public AuthSevice(UserManager<User> userManager, IConfiguration configuration , IMapper mapper,IOptions<Jwt> jwt )
    {
        _userManager = userManager;
        _configuration = configuration;
        _mapper = mapper;
        _jwt = jwt.Value; 
    }

    public async Task<AuthDto> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName);
        AuthDto authDto = new AuthDto();
        if (user == null)
        {
            authDto.Message = "User not found";
        }
        else
        {
            bool isAuth = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isAuth)
            {
                authDto.Message = "Password is wrong";
            }
            var token = await CreateJwtToken(user);
            var claims =await _userManager.GetClaimsAsync(user);
            var tokenHandeler = new JwtSecurityTokenHandler();
            authDto.Token = tokenHandeler.WriteToken(token);
            authDto.IsAuthenticated = true;
            authDto.Username = user.UserName;
            authDto.Email = user.Email;
            authDto.Role = claims.Where(a => a.Type == ClaimTypes.Role).FirstOrDefault()!.Value;
            authDto.Id= claims.Where(a => a.Type == ClaimTypes.NameIdentifier).FirstOrDefault()!.Value;

        }
        
        return authDto;
    }

    public async Task<AuthDto> RegisterAsync(RegisterDto dto)
    {
        if (await _userManager.FindByEmailAsync(dto.Email) != null)
            return new AuthDto { Message = "Email is already registered " };
        if (await _userManager.FindByNameAsync(dto.UserName) != null)
            return new AuthDto { Message = "UserName is already registered" };

            var user = new User();
            if(dto.Role=="Admin")
            {
              user = _mapper.Map<Hospital>(dto);
            }
            else if (dto.Role == "Doctor")
            {
                 user = _mapper.Map<Doctor>(dto);
            }
            else if(dto.Role=="Patient")
            {
                 user = _mapper.Map<Patient>(dto);
            }
            else
            {
            return new AuthDto { Message = "Role is Not Found " };
            }
        var result = await _userManager.CreateAsync(user, dto.Password);
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Role ,dto.Role),
            new Claim(ClaimTypes.Email , user.Email) ,
            new Claim(ClaimTypes.Name , user.Name),
            new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString())
        };
        
        if (!result.Succeeded)
            {
            string errors = string.Empty;
            foreach (var error in result.Errors)
                errors += $"{error.Description}"; 
            return new AuthDto { Message = errors }; 
            }
       await _userManager.AddClaimsAsync(user, claims);
        var jwtSecurityToken = await CreateJwtToken(user, dto.Role);
        return new AuthDto
        {
            Email = user.Email,
            Username = user.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            IsAuthenticated = true,
            ExpiresOn = jwtSecurityToken.ValidTo,
            Role = claims.Where(a => a.Type == ClaimTypes.Role).FirstOrDefault()!.Value
        };
        
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
    private async Task<JwtSecurityToken> CreateJwtToken(User user, string role)
    {
        string key = _jwt.Key; 
        var keyinbytes = Encoding.ASCII.GetBytes(key);
        var symmetricSecurityKey = new SymmetricSecurityKey(keyinbytes);
        var siginingcredintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtsecuritytoken = new JwtSecurityToken(

            signingCredentials: siginingcredintials,
            expires: DateTime.Now.AddDays(_jwt.DurationInDays) ,
            issuer:_jwt.Issuer , 
            audience: _jwt.Audience
            );
        return jwtsecuritytoken;
    }
    private async Task<JwtSecurityToken> CreateJwtToken(User user)
    {

        var claims=await _userManager.GetClaimsAsync(user);
        //string key = _configuration.GetValue<string>("key") ?? string.Empty;
        string key=_jwt.Key;
        var keyinbytes = Encoding.ASCII.GetBytes(key);
        var symmetricSecurityKey = new SymmetricSecurityKey(keyinbytes);
        var siginingcredintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(

            claims: claims,
            signingCredentials: siginingcredintials,
            issuer:_jwt.Issuer ,
            audience:_jwt.Audience,    
            expires: DateTime.Now.AddDays(_jwt.DurationInDays)
            );
        return jwtSecurityToken;
    }

}
