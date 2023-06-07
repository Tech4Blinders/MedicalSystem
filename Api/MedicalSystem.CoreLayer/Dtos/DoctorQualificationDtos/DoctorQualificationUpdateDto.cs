namespace MedicalSystem.CoreLayer
{
    public class UpdateDoctorQualificationDto
    {
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public string Certification { get; set; } = string.Empty;

        public string CertificationFrom { get; set; } = string.Empty;
    }
}
