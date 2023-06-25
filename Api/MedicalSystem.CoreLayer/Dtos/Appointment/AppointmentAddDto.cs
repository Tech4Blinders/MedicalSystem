using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.CoreLayer;

public class AppointmentAddDto
{
    public DateTime AppointmentDate { get; set; }
    public int Cost { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public int BranchId { get; set; }
    public int? ZoomMeetingId { get; set; }  
    public Boolean isOnline { get; set; }
}
