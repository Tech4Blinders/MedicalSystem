using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalSystem.Api;

public class AuthSevice 
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AuthSevice(UserManager<User> userManager  , IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    private async Task<JwtSecurityToken> CreateJwtToken(User user, string role)
    {

     var claims = new List<Claim>()
    {
       new Claim(ClaimTypes.Role , role==String.Empty?"patient":role),
       new Claim(ClaimTypes.Email , user.Email) ,
       new Claim(ClaimTypes.Name , user.Name),
       new Claim(ClaimTypes.NameIdentifier ,user.Id.ToString())
    };
        await _userManager.AddClaimsAsync(user , claims);


        string key = _configuration.GetValue<string>("key") ?? string.Empty;
        var keyinbytes = Encoding.ASCII.GetBytes(key);
        var symmetricSecurityKey = new SymmetricSecurityKey(keyinbytes); 
        var siginingcredintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtsecuritytoken = new JwtSecurityToken(
            
            claims:claims , 
            signingCredentials:siginingcredintials,
            expires:DateTime.Now.AddDays(20) 
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

        var jwtsecuritytoken = new JwtSecurityToken(

            claims: claims,
            signingCredentials: siginingcredintials,
            expires: DateTime.Now.AddDays(20)
            );
        return jwtsecuritytoken;
    }

}
