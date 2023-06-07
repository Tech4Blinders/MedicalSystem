using System.ComponentModel.DataAnnotations;

namespace MedicalSystem.CoreLayer;

public class ReportAddDto
{
    public string Description { get; set; } = string.Empty;
    public string Prescription { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int AppointmentId { get; set; }
}
