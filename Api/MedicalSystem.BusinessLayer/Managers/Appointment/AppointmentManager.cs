﻿using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

public class AppointmentManager : IAppointmentManager
{
    private readonly IUnitOfWork _unitOfWork;
    public AppointmentManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int AddAppointment(AppointmentAddDto appointmentToAdd)
    {
        Appointment newAppointment = new Appointment
        {
            AppointmentDate = appointmentToAdd.AppointmentDate,
            Cost = appointmentToAdd.Cost,
            DoctorId = appointmentToAdd.DoctorId,
            PatientId = appointmentToAdd.PatientId,
            BranchId = appointmentToAdd.BranchId,
            isOnline = appointmentToAdd.isOnline,
            ZoomMeetingId=appointmentToAdd?.ZoomMeetingId
        };
        _unitOfWork._AppointmentRepo.AddAsync(newAppointment);
        _unitOfWork.SaveChanges();
        return newAppointment.Id;
    }

    public async Task<bool> DeleteAppointment(int id)
    {
        Appointment? appointmentToDelete = await _unitOfWork._AppointmentRepo.GetByIdAsync(id);
        if (appointmentToDelete == null)
        {
            return false;
        }
        _unitOfWork._AppointmentRepo.Delete(appointmentToDelete);
        return true;
    }

    public async Task<List<AppointmentReadDto>> GetAllAppointments()
    {
       var Appointments = await _unitOfWork._AppointmentRepo.GetWith(null, new string [] {"Branch","Doctor","Patient"});
        if (Appointments == null)
        {
            return new List<AppointmentReadDto>();
        }
        return Appointments.Select(appointment => new AppointmentReadDto
        {
            Id = appointment.Id,
            AppointmentDate = appointment.AppointmentDate,
            Cost = appointment.Cost,
            Doctor = new AppointmentDoctorReadDto
            {
                Id = appointment.Doctor!.Id,
                Name = appointment.Doctor!.Name,
                PhoneNumber = appointment.Doctor!.PhoneNumber,
                Gender = appointment.Doctor!.Gender,
                Email = appointment.Doctor!.Email,
                Country = appointment.Doctor!.Country,
                City = appointment.Doctor!.City,
                Street = appointment.Doctor!.Street,
            },
            Branch = new AppointmentBranchReadDto
            {
                Id = appointment.Branch!.Id,
                Name = appointment.Branch!.Name,
                PhoneNumber = appointment.Branch!.PhoneNumber,
            },
            Patient = new PatientReadDto
            {
                Name = appointment.Patient.Name,
                PhoneNumber = appointment.Patient.PhoneNumber,
                Gender = appointment.Patient.Gender,
                Age = appointment.Patient.Age,
                Email = appointment.Patient.Email,
                Id = appointment.Patient.Id,
            }

        }).ToList();
    }

    public AppointmentReadDto? GetAppointmentById(int id)
    {
        Appointment appointment = _unitOfWork._AppointmentRepo.GetAppointmentById(id);
        if (appointment == null)
        {
            return new AppointmentReadDto();
        }
        return new AppointmentReadDto
        {
            Id = appointment.Id,
            AppointmentDate = appointment.AppointmentDate,
            Cost = appointment.Cost,
            Doctor = new AppointmentDoctorReadDto
            {
                Id = appointment.Doctor!.Id,
                Name = appointment.Doctor!.Name,
                PhoneNumber = appointment.Doctor!.PhoneNumber,
                Gender = appointment.Doctor!.Gender,
                Email = appointment.Doctor!.Email,
                Country = appointment.Doctor!.Country,
                City = appointment.Doctor!.City,
                Street = appointment.Doctor!.Street,
            },
            Branch = new AppointmentBranchReadDto
            {
                Id = appointment.Branch!.Id,
                Name = appointment.Branch!.Name,
                PhoneNumber = appointment.Branch!.PhoneNumber,
            },
            Patient = new PatientReadDto
            {
                Name = appointment.Patient.Name,
                PhoneNumber = appointment.Patient.PhoneNumber,
                Gender = appointment.Patient.Gender,
                Age = appointment.Patient.Age,
                Email = appointment.Patient.Email,
                Id = appointment.Patient.Id,
            }
        };
    }

    public bool UpdateAppointment(AppointmentUpdateDto AppointmentUpdateDto)
    {
        Appointment appointment = _unitOfWork._AppointmentRepo.GetAppointmentById(AppointmentUpdateDto.appointmentId);
        {
            if (appointment == null)
            {
                return false;
            }
            appointment.ZoomMeetingId = AppointmentUpdateDto.meetingId;
            _unitOfWork.SaveChanges();
            return true;
        }
    }
    public IEnumerable<AppointmentReadDto> GetAppointmentByDoctor(int id)
    {
        var appointment = _unitOfWork._AppointmentRepo.GetWith(a => a.DoctorId == id, new string[] { "Branch", "Patient" }).Result;
        if (appointment is null)
        {
            return new List<AppointmentReadDto>();
        }
        return appointment.Select(appointment => new AppointmentReadDto
        {
            Id = appointment.Id,
            AppointmentDate = appointment.AppointmentDate,
            Cost = appointment.Cost,
            Branch = new AppointmentBranchReadDto
            {
                Id = appointment.Branch!.Id,
                Name = appointment.Branch!.Name,
                PhoneNumber = appointment.Branch!.PhoneNumber,
            },
            Patient = new PatientReadDto
            {
                Name = appointment.Patient.Name,
                PhoneNumber = appointment.Patient.PhoneNumber,
                Gender = appointment.Patient.Gender,
                Age = appointment.Patient.Age,
                Email = appointment.Patient.Email,
                Id = appointment.Patient.Id,
            }

        }).ToList();

    }

    public IEnumerable<AppointmentReadDto> GetAppointmentByPatient(int id)
    {
        var appointment = _unitOfWork._AppointmentRepo.GetWith(a => a.PatientId == id, new string[] { "Branch", "Doctor" }).Result;
        if (appointment is null)
        {
            return new List<AppointmentReadDto>();
        }
        return appointment.Select(appointment => new AppointmentReadDto
        {
            Id = appointment.Id,
            AppointmentDate = appointment.AppointmentDate,
            Cost = appointment.Cost,
            Doctor = new AppointmentDoctorReadDto
            {
                Id = appointment.Doctor!.Id,
                Name = appointment.Doctor!.Name,
                PhoneNumber = appointment.Doctor!.PhoneNumber,
                Gender = appointment.Doctor!.Gender,
                Email = appointment.Doctor!.Email,
                Country = appointment.Doctor!.Country,
                City = appointment.Doctor!.City,
                Street = appointment.Doctor!.Street,
            },
            Branch = new AppointmentBranchReadDto
            {
                Id = appointment.Branch!.Id,
                Name = appointment.Branch!.Name,
                PhoneNumber = appointment.Branch!.PhoneNumber,
            },

        }).ToList();

    }
    
	
}
