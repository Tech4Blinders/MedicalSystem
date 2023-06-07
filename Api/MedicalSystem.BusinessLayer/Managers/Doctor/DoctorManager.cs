using AutoMapper;
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

public class DoctorManager:IDoctorManager
{// Auto.Mapper
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public ReadDoctorDto Add(AddDoctorDto doctorDto)
    {
        var doctordb = _mapper.Map<Doctor>(doctorDto);
        doctordb.Name = doctorDto.Name;
        doctordb.Gender = doctorDto.Gender;
        doctordb.Email = doctorDto.Email;
        doctordb.PhoneNumber = doctorDto.PhoneNumber;
        doctordb.City = doctorDto.City;
        doctordb.Country = doctorDto.Country;
        doctordb.Street = doctorDto.Street;
        // doctordb.Clinic - _unitOfWork._ClinicRepo.GetById(doctorDto.ClinicId);
        // doctordb.Department = _unitOfWork.DepartmentRepo.GetById(doctorDto.DepartmentId); 
        _unitOfWork._DoctorRepo.AddAsync(doctordb);
        _unitOfWork.SaveChanges();
        return _mapper.Map<ReadDoctorDto>(doctordb);
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

    public IEnumerable<ReadDoctorDto> GetAll(string[]? includes = null)
    {
        var doctorsfromdb = _unitOfWork._DoctorRepo.GetWith(null,includes);
        return _mapper.Map<IEnumerable<ReadDoctorDto>>(doctorsfromdb);

    }

    public ReadDoctorDto? GetById(int id)
    {
        var doctorfromdb = _unitOfWork._DoctorRepo.GetByIdAsync(id);
        if (doctorfromdb == null)
            return null;
        return _mapper.Map<ReadDoctorDto>(doctorfromdb);

    }

    public bool Update(UpdateDoctorDto doctorDto)
    {
        var doctorfromdb = _unitOfWork._DoctorRepo.GetByIdAsync(doctorDto.Id).Result;
        if (doctorfromdb == null) return false;
        doctorfromdb.Email = doctorDto.Email;
        _mapper.Map(doctorDto, doctorfromdb);
        _unitOfWork._DoctorRepo.Update(doctorfromdb);
        _unitOfWork.SaveChanges();
        return true;

    }
}
