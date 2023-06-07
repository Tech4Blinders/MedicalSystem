﻿using MedicalSystem.CoreLayer;
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
            .Include(appointment => appointment.Doctor)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Branch)
            .ToList();
    }

    public Appointment? GetAppointmentById(int id)
    {
        return _context.Set<Appointment>().FirstOrDefault(appointment => appointment.Id == id);
    }
}