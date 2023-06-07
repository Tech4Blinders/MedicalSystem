using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer;

public class AppointmentReadDto
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int Cost { get; set; }

    public AppointmentDoctorReadDto? Doctor { get; set; }
    public PatientReadDto? Patient { get; set; }
    public AppointmentBranchReadDto? Branch { get; set; }
}
