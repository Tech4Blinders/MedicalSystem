using MedicalSystem.BusinessLayer;
using MedicalSystem.BusinessLayer.Managers.IdentityDtos;

namespace MedicalSystem.Api.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthDto> RegisterAsync(RegisterDto dto);
        Task<AuthDto> LoginAsync(LoginDto dto);


    }
}
