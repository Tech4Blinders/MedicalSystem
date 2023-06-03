using MedicalSystem.DataAccessLayer.Models.Doctor_Qualifications;
using MedicalSystem.DataAccessLayer.Repos.MainRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Models.Doctor
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty; 
        public string? Email { get; set; } =string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public ICollection<DoctorQualification> DoctorQualifications { get; set; } = new HashSet<DoctorQualification>();

    }
}
