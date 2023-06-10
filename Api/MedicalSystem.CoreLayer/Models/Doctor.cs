using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string Image { get; set; } = String.Empty;
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("Clinic")]
        public int ClinicId { get;set; }
        public Clinic? Clinic { get; set;}
        public ICollection<DoctorQualification> DoctorQualifications { get; set; } = new HashSet<DoctorQualification>();
        public ICollection<Appointment> Appointments { get; set; }= new HashSet<Appointment>();
        public ICollection<BranchDoctor> BranchDoctors { get; set; } = new HashSet<BranchDoctor>();

    }
}
