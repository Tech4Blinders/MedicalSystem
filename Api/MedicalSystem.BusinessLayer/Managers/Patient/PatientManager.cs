using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicalSystem.BusinessLayer;

public class PatientManager : IPatientManager
{
    private readonly IUnitOfWork _unitOfWork;
    public PatientManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    

    public int Add(PatientAddDto patientAddDto)
    {
        var patient = new Patient
        {
            Name = patientAddDto.Name,
            Age = patientAddDto.Age,
            Email = patientAddDto.Email,
            Gender = patientAddDto.Gender,
            PhoneNumber = patientAddDto.PhoneNumber,
        };
        _unitOfWork._PatientRepo.AddAsync(patient);
        _unitOfWork.SaveChanges();
        return patient.Id;
    }

    public async void Delete(int id)
    {
        var patient= await  _unitOfWork._PatientRepo.GetByIdAsync(id);
        if(patient is null)
        {
            return;
        }
        _unitOfWork._PatientRepo.Delete(patient);

    }

    public List<PatientReadDto> GetAll()
    {
        IEnumerable<Patient> patients=_unitOfWork._PatientRepo.GetAllAsyn().Result;
        if (patients is null)
        {
            return new List<PatientReadDto>();
        }

        return patients.Select(a => new PatientReadDto
        {
            Id = a.Id,
            Name = a.Name,
            Age = a.Age,

            Email = a.Email,
            Gender = a.Gender,

        }).ToList();

    }

    public Patient? GetById(int id)
    {
        var patient= _unitOfWork._PatientRepo.GetByIdAsync(id).Result;
        if (patient is null)
            return null;
        return patient;
    }

    public bool Update(PatientUpdateDto patientUpdateDto)
    {
        var patientfromdb = _unitOfWork._PatientRepo.GetByIdAsync(patientUpdateDto.Id).Result;
        if (patientfromdb is null) return false;
        patientfromdb.Email=patientUpdateDto.Email;
        patientfromdb.Name = patientUpdateDto.Name;
        patientfromdb.Age = patientUpdateDto.Age;
        patientfromdb.Gender = patientfromdb.Gender;
        _unitOfWork._PatientRepo.Update(patientfromdb);
        return true;

    }
}
