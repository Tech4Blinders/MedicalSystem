using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer
{
    public class BranchDoctor
    {
        public int BranchId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StaringDate { get; set; }
        public Branch? Branch { get; set; }
        //public Doctor? Doctor { get; set; }

    }
}
