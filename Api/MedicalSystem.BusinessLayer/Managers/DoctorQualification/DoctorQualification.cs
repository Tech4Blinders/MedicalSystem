

using AutoMapper;
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

    public class DoctorQualificationManager :IDoctorQualificationManager
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
        var doctorqualificationfromdb = new DoctorQualification
        {
        DoctorId = dto.DoctorId,
        Certification = dto.Certification,
        CertificationFrom = dto.CertificationFrom
        };
       

        _unitOfWork._DoctorQualificationRepo.AddAsync(doctorqualificationfromdb);
        _unitOfWork.SaveChanges();
        return new ReadDoctorQualificationDto
        {
            DoctorId = doctorqualificationfromdb.DoctorId,
            Certification = doctorqualificationfromdb.Certification,
            CertificationFrom = doctorqualificationfromdb.CertificationFrom
        };
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
        var Alldoctorqualification = _unitOfWork._DoctorQualificationRepo.GetWith().Result;
        return Alldoctorqualification.Select(a=> new ReadDoctorQualificationDto
        {
            DoctorId=a.DoctorId,
            Certification = a.Certification,
            CertificationFrom = a.CertificationFrom,
        });
    }


    public ReadDoctorQualificationDto GetById(int id)
    {
        var docqualification = _unitOfWork._DoctorQualificationRepo.GetByIdAsync(id).Result;
        if (docqualification == null) return new ReadDoctorQualificationDto();
        return new ReadDoctorQualificationDto
        {
            DoctorId=docqualification.DoctorId,
            Certification=docqualification.Certification,
            CertificationFrom=docqualification.CertificationFrom
        };
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

