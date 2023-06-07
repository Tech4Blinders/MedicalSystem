

using AutoMapper;
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

    public class DoctorQualificationManager
{    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorQualificationManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public ReadDoctorQualificationDto Add(AddDoctorQualificationDto dto)
    {
        var doctorqualificationfromdb = _mapper.Map<DoctorQualification>(dto);
        doctorqualificationfromdb.DoctorId = dto.DoctorId;
        doctorqualificationfromdb.Certification = dto.Certification;
        doctorqualificationfromdb.CertificationFrom = dto.CertificationFrom;

        _unitOfWork._DoctorQualificationRepo.AddAsync(doctorqualificationfromdb);
        _unitOfWork.SaveChanges();
        return _mapper.Map<ReadDoctorQualificationDto>(doctorqualificationfromdb);
    }

    public bool Delete(int id)
    {
        var docqualification = _unitOfWork._DoctorQualificationRepo.GetByIdAsync(id).Result;
        if (docqualification == null)
            return false;
        _unitOfWork._DoctorQualificationRepo.Delete(docqualification);
        _unitOfWork.SaveChanges();
        return true;

    }

    public IEnumerable<ReadDoctorQualificationDto> GetAll()
    {
        var Alldoctorqualification = _unitOfWork._DoctorQualificationRepo.GetWith();
        return _mapper.Map<IEnumerable<ReadDoctorQualificationDto>>(Alldoctorqualification);
    }


    public ReadDoctorQualificationDto GetById(int id)
    {
        var docqualification = _unitOfWork._DoctorQualificationRepo.GetByIdAsync(id).Result;
        if (docqualification == null) return new ReadDoctorQualificationDto();
        return _mapper.Map<ReadDoctorQualificationDto>(docqualification);
    }

    public bool Update(UpdateDoctorQualificationDto dto)
    {
        var docqualification = _unitOfWork._DoctorQualificationRepo.GetByIdAsync(dto.DoctorId).Result;
        if (docqualification == null) return false;
        _unitOfWork._DoctorQualificationRepo.Update(docqualification);
        _unitOfWork.SaveChanges();
        return true;
    }
}

