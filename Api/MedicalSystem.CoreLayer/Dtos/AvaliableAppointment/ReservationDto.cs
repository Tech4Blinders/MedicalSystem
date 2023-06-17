namespace MedicalSystem.CoreLayer;

public class ReservationDto
{
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public int BranchId { get; set; }
    public string Type { get; set; } = "Offline";
    public DateTime Date { get; set; }
    public int Cost { get; set; }
}
