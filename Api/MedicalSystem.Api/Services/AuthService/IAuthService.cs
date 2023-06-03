namespace MedicalSystem.Api.Services.AuthService
{
    public interface IAuthService
    {
        public string Login(string username, string password);
        public string Register(string username, string password);
    }
}
