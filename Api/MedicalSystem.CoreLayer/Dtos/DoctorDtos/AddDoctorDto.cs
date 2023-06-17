using Microsoft.AspNetCore.Http;
namespace MedicalSystem.CoreLayer
{
    public class AddDoctorDto
    {

        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public int ClinicId { get; set; }
        public IFormFile? File { get; set; }
        public decimal OfflineCost { get; set; }
        public decimal? OnlineCost { get; set; }
    }
}


