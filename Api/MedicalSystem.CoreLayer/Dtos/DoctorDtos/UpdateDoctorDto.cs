namespace MedicalSystem.CoreLayer;

public class UpdateDoctorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public string? Gender { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Country { get; set; } = string.Empty;
    public string? City { get; set; } = string.Empty;
    public string? Street { get; set; } = string.Empty;
    public int ClinicId { get; set; }
    public int DepartmentId { get; set; }
    public decimal OfflineCost { get; set; }
    public decimal? OnlineCost { get; set; }
}
