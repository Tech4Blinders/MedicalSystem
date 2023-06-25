using MedicalSystem.BusinessLayer;
using MedicalSystem.BusinessLayer.Managers.IdentityDtos;

namespace MedicalSystem.Api.Services.AuthService
using MedicalSystem.CoreLayer;

namespace MedicalSystem.Api.Services
{
    public interface IAuthService
    {
        Task<AuthDto> RegisterAsync(RegisterDto dto);
        Task<AuthDto> LoginAsync(LoginDto dto);


    }
        public string Login(string username, string password);
        public string Register(string username, string password);
        public dynamic JWTGenerator(User user);

	}
}
