using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer.Dtos.BranchDtos
{
    public class ReadBranchDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int HospitalId { get; set; }

        public int BranchAddressId { get; set; }
    }
}
