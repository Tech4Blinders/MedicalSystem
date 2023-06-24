using MedicalSystem.CoreLayer;

namespace MedicalSystem.Api.Services
{
    public interface IAuthService
    {
        public string Login(string username, string password);
        public string Register(string username, string password);
        public dynamic JWTGenerator(User user);

	}
}
