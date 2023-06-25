using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer.Dtos.DoctorDtos
{
    public class DoctorInClinicDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
