using MedicalSystem.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer;

public interface IAppointmentRepo : IGenericRepo<Appointment>
{
    List<Appointment>? GetAllAppointments();
    Appointment? GetAppointmentById(int id);
}
