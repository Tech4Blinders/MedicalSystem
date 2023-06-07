using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public interface IDoctorManager
{
    IEnumerable<ReadDoctorDto> GetAll(string[]? includes = null);
    ReadDoctorDto? GetById(int id);
    ReadDoctorDto Add(AddDoctorDto doctorDto);
    bool Update(UpdateDoctorDto doctorDto);
    bool Delete(int id);

}
