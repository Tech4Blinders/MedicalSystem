using AutoMapper;
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
            var tokenHandeler = new JwtSecurityTokenHandler();
            authDto.Token = tokenHandeler.WriteToken(token);
            authDto.IsAuthenticated = true;
            authDto.Username = user.UserName;
            authDto.Email = user.Email;
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
           if(!result.Succeeded)
            {
            string errors = string.Empty;
            foreach (var error in result.Errors)
                errors += $"{error.Description}"; 
            return new AuthDto { Message = errors }; 
            }
        var jwtSecurityToken = await CreateJwtToken(user, dto.Role);
        return new AuthDto
        {
            Email = user.Email,
            Username = user.UserName,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken) ,
            IsAuthenticated =true,
            ExpiresOn = jwtSecurityToken.ValidTo ,
            Role = jwtSecurityToken.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.Role).Value 
        };
        
    }

    private async Task<JwtSecurityToken> CreateJwtToken(User user, string role)
    {

    var claims = new List<Claim>()
    {
       new Claim(ClaimTypes.Role , role == String.Empty ? "patient" : role),
       new Claim(ClaimTypes.Email , user.Email) ,
       new Claim(ClaimTypes.Name , user.Name),
       new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString())
    };
        await _userManager.AddClaimsAsync(user, claims);


        string key = _jwt.Key; 
        var keyinbytes = Encoding.ASCII.GetBytes(key);
        var symmetricSecurityKey = new SymmetricSecurityKey(keyinbytes);
        var siginingcredintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtsecuritytoken = new JwtSecurityToken(

            claims: claims,
            signingCredentials: siginingcredintials,
            expires: DateTime.Now.AddDays(_jwt.DurationInDays) ,
            issuer:_jwt.Issuer , 
            audience: _jwt.Audience
            );
        return jwtsecuritytoken;
    }
    private async Task<JwtSecurityToken> CreateJwtToken(User user)
    {

        var claims = new List<Claim>()
    {
       new Claim(ClaimTypes.Email , user.Email) ,
       new Claim(ClaimTypes.Name , user.Name),
       new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString())
    };
        await _userManager.AddClaimsAsync(user, claims);


        string key = _configuration.GetValue<string>("key") ?? string.Empty;
        var keyinbytes = Encoding.ASCII.GetBytes(key);
        var symmetricSecurityKey = new SymmetricSecurityKey(keyinbytes);
        var siginingcredintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(

            claims: claims,
            signingCredentials: siginingcredintials,
            issuer:_jwt.Issuer ,
            audience:_jwt.Audience ,    
            expires: DateTime.Now.AddDays(_jwt.DurationInDays)
            );
        return jwtSecurityToken;
    }

}
