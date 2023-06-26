using MedicalSystem.CoreLayer;
using MedicalSystem.CoreLayer.Dtos.ClinicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer.Dtos.BranchDtos
{
    public class BranchWithClinicWithDocDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public ICollection<ClinicsWithDoctorDto> clinics { get; set; } = new HashSet<ClinicsWithDoctorDto>();
     
    }
}
