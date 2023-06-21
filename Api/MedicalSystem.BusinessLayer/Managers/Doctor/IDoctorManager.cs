using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public interface IDoctorManager
{
    IEnumerable<ReadDoctorDto> GetAll(string[]? includes = null);
    IEnumerable<ReadDoctorDto> GetDocByClinicId(int clinicId);
    ReadDoctorDto? GetById(int id);
    Task<ReadDoctorDto> Add(AddDoctorDto doctorDto);
    bool Update(UpdateDoctorDto doctorDto);
    bool Delete(int id);

}
