using MedicalSystem.BusinessLayer;
using MedicalSystem.BusinessLayer.Managers.IdentityDtos;
using System.IdentityModel.Tokens.Jwt;

namespace MedicalSystem.CoreLayer
{
    public interface IAuthService
    {
        Task<AuthDto> RegisterAsync(RegisterDto dto);
        Task<AuthDto> LoginAsync(LoginDto dto);
        //public string Login(string username, string password);
        //public string Register(string username, string password);
        public dynamic JWTGenerator(User user);
        public Task<JwtSecurityToken> CreateJwtToken(User user);

    }
}
