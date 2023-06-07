using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer
{
    public interface IDoctorQualificationManager
    {
        IEnumerable<ReadDoctorQualificationDto> GetAll();
        ReadDoctorQualificationDto GetById(int id);
        ReadDoctorQualificationDto Add(AddDoctorQualificationDto dto);
        bool Update(UpdateDoctorQualificationDto dto);
        bool Delete(int id);
    }
}
