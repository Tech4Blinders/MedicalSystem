﻿using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public interface IAppointmentManager
{
    Task<List<AppointmentReadDto>> GetAllAppointments();
    AppointmentReadDto? GetAppointmentById(int id);
    int AddAppointment(AppointmentAddDto appointmentToAdd);
    bool UpdateAppointment(AppointmentUpdateDto appointmentToUpdate);
    Task<bool> DeleteAppointment(int id);
    public IEnumerable<AppointmentReadDto> GetAppointmentByDoctor(int id);
    public IEnumerable<AppointmentReadDto> GetAppointmentByPatient(int id);


}
