using MedicalSystem.CoreLayer.Dtos.DoctorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer.Dtos.ClinicDtos
{
    public class ClinicsWithDoctorDto
    {
        public int id { get; set; }
        public string Specilization { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RoomNumber { get; set; }
        public string Image { get; set; } = string.Empty;
        public ICollection<DoctorInClinicDto> Doctors { get; set; } = new HashSet<DoctorInClinicDto>();
    }
}
