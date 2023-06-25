using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer.Dtos.BranchDtos
{
    public class HospitalWithBranches
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<BranchWithClinicWithDocDTO> branches { get; set; } = new HashSet<BranchWithClinicWithDocDTO>();
    }
}
