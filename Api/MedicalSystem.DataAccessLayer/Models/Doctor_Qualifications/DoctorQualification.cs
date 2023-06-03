using MedicalSystem.DataAccessLayer.Models.Doctor;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Models.Doctor_Qualifications
{
    public class DoctorQualification
    {
        [ForeignKey("doctorId")]
        public int DoctorId { get; set; }
        public Doctor.Doctor? Doctor { get; set; } 
        public string Certification { get; set; } = string.Empty; 

        public string CertificationFrom { get; set; } = string.Empty;   

    }
}
