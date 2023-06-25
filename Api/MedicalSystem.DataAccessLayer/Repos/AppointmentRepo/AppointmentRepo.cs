using MedicalSystem.CoreLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer;

public class AppointmentRepo : GenericRepo<Appointment>, IAppointmentRepo
{
    private readonly ApplicationDbContext _context;
    public AppointmentRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Appointment>? GetAllAppointments()
    {
        return _context.Set<Appointment>()
            .Include("Doctor")
            .Include("Branch")
            .Include("Patient")
            .ToList();
    }

    public Appointment? GetAppointmentById(int id)
    {
        return _context
            .Set<Appointment>()
            .Include(app=>app.ZoomMeeting)
            .FirstOrDefault(appointment => appointment.Id == id);
    }
}
