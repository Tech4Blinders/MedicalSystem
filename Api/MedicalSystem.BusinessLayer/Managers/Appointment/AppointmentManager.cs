using MedicalSystem.CoreLayer;
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

    public List<AppointmentReadDto> GetAllAppointments()
    {
        IEnumerable<Appointment> Appointments = _unitOfWork._AppointmentRepo.GetAllAppointments();
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

    public bool UpdateAppointment(AppointmentUpdateDto patientUpdateDto)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<AppointmentReadDto> GetAppointmentByDoctor(int id)
    {
        var appointment = _unitOfWork._AppointmentRepo.GetWith(a => a.DoctorId == id, new string[] {"Branch","Patient"}).Result;
        if(appointment is null)
        {
            return new List<AppointmentReadDto>();
        }
        return appointment.Select(appointment => new AppointmentReadDto
        {
            Id = appointment.Id,
            AppointmentDate=appointment.AppointmentDate,
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
        var appointment = _unitOfWork._AppointmentRepo.GetWith(a => a.PatientId == id, new string[] {"Branch","Doctor"}).Result;
        if(appointment is null)
        {
            return new List<AppointmentReadDto>();
        }
        return appointment.Select(appointment => new AppointmentReadDto
        {
            Id = appointment.Id,
            AppointmentDate=appointment.AppointmentDate,
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
