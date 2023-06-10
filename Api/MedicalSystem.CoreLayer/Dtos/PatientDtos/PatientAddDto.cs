using Microsoft.AspNetCore.Http;

namespace MedicalSystem.CoreLayer
{
    public class PatientAddDto
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public IFormFile File { get; set; }
    }
}
