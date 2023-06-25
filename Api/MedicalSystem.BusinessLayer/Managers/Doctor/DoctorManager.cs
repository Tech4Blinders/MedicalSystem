using AutoMapper;
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

public class DoctorManager : IDoctorManager
{// Auto.Mapper
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ReadDoctorDto> Add(AddDoctorDto doctorDto)
    {
        var newDoctor = new Doctor
        {
            Name = doctorDto.Name,
            City = doctorDto.City,
            Country = doctorDto.Country,
            Street = doctorDto.Street,
            Email = doctorDto.Email,
            Image = doctorDto.Image ?? "",
            PhoneNumber = doctorDto.PhoneNumber,
            OfflineCost = doctorDto.OfflineCost,
            OnlineCost = doctorDto.OnlineCost,
            ClinicId = doctorDto.ClinicId,
            DepartmentId = doctorDto.DepartmentId,
            Gender = doctorDto.Gender

        };
        await _unitOfWork._DoctorRepo.AddAsync(newDoctor);
        _unitOfWork.SaveChanges();
        return new ReadDoctorDto
        {
            Name = newDoctor.Name,
            City = newDoctor.City,
            Country = newDoctor.Country,
            Street = newDoctor.Street,
            Email = newDoctor.Email,
            Image = newDoctor.Image,
            PhoneNumber = newDoctor.PhoneNumber,
            OfflineCost = newDoctor.OfflineCost,
            OnlineCost = newDoctor.OnlineCost,
            DepartmentId = newDoctor.DepartmentId,
            ClinicId = newDoctor.ClinicId,
            Gender = newDoctor.Gender
        };
    }

    public bool Delete(int id)
    {
        var doctorfromdb = _unitOfWork._DoctorRepo.GetByIdAsync(id).Result;
        if (doctorfromdb == null)
            return false;
        _unitOfWork._DoctorRepo.Delete(doctorfromdb);
        _unitOfWork.SaveChanges();
        return true;

    }

    public IEnumerable<ReadDoctorDto> GetAll(string[]? includes=null )
    {
        var doctorsfromdb = _unitOfWork._DoctorRepo.GetWith(null, new string[] {"Department","Clinic"/*, "DoctorQualification"*/ }).Result;
        return doctorsfromdb.Select(a => new ReadDoctorDto
        {
            Id=a.Id,
            Name = a.Name,
            City = a.City,
            Country = a.Country,
            Street = a.Street,
            Email = a.Email,
            Image = a.Image,
            PhoneNumber = a.PhoneNumber,
            OfflineCost = a.OfflineCost,
            OnlineCost = a.OnlineCost,
            DepartmentId = a.DepartmentId,
            ClinicId = a.ClinicId,
            DepartmentName = a.Department?.Name ?? "",
            ClinicName = a.Clinic?.Description ?? "",
            Gender = a.Gender,
            //Certification = a.DoctorQualifications.Select(a => a.Certification)?.ToString(),
            //CertificationFrom = a.DoctorQualifications.Select(a => a.CertificationFrom)?.ToString()
        }).ToList();

    }

    public ReadDoctorDto? GetById(int id)
    {
        var doctorfromdb = _unitOfWork._DoctorRepo.GetByIdAsync(id).Result;
        if (doctorfromdb == null)
            return null;
        return new ReadDoctorDto
        {
            Name = doctorfromdb.Name,
            City = doctorfromdb.City,
            Country = doctorfromdb.Country,
            Street = doctorfromdb.Street,
            Email = doctorfromdb.Email,
            Image = doctorfromdb.Image,
            PhoneNumber = doctorfromdb.PhoneNumber,
            OfflineCost = doctorfromdb.OfflineCost,
            OnlineCost = doctorfromdb.OnlineCost,
            DepartmentId = doctorfromdb.DepartmentId,
            ClinicId = doctorfromdb.ClinicId,
            Gender = doctorfromdb.Gender
        };

    }

    public IEnumerable<ReadDoctorDto> GetDocByClinicId(int clinicId)
    {
        var doctors = _unitOfWork._DoctorRepo.getDocByClinicId(clinicId);
        return doctors.Select(a => new ReadDoctorDto
        {
            Id=a.Id,
            Name = a.Name,
            City = a.City,
            Country = a.Country,
            Street = a.Street,
            Email = a.Email,
            Image = a.Image,
            PhoneNumber = a.PhoneNumber,
            OfflineCost = a.OfflineCost,
            OnlineCost = a.OnlineCost,
            DepartmentId = a.DepartmentId,
            ClinicId = a.ClinicId,
            DepartmentName = a.Department?.Name ?? "",
            ClinicName = a.Clinic?.Description ?? "",
            Gender = a.Gender,
        }).ToList();
    }

    public bool Update(UpdateDoctorDto doctorDto)
    {
        var doctorfromdb = _unitOfWork._DoctorRepo.GetByIdAsync(doctorDto.Id).Result;
        if (doctorfromdb == null) return false;
        doctorfromdb.Name = doctorDto.Name;
        doctorfromdb.Street = doctorDto.Street;
        doctorfromdb.Country = doctorDto.Country;
        doctorfromdb.PhoneNumber = doctorDto.PhoneNumber;
        doctorfromdb.City = doctorfromdb.City;
        doctorfromdb.Email = doctorfromdb.Email;
        doctorfromdb.ClinicId = doctorfromdb.ClinicId;
        doctorfromdb.DepartmentId = doctorfromdb.DepartmentId;
        doctorfromdb.OfflineCost = doctorfromdb.OfflineCost;
        doctorfromdb.OnlineCost = doctorfromdb.OnlineCost;
        doctorfromdb.Gender = doctorfromdb.Gender;
        _unitOfWork._DoctorRepo.Update(doctorfromdb);
        _unitOfWork.SaveChanges();
        return true;

    }
}
