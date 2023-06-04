using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.CoreLayer
{
    public class DoctorQualification
    {
        [ForeignKey("doctorId")]
        public int DoctorId { get; set; }
        public Doctor? Doctor  { get; set; }
        public string Certification { get; set; } = string.Empty;

        public string CertificationFrom { get; set; } = string.Empty;

    }
}
