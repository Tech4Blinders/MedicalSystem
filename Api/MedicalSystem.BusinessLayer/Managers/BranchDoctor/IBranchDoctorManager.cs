using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public interface IBranchDoctorManager
{
    List<BranchDoctorReadDto> GetAll();
    BranchDoctor? GetById(int id);
    int Add(BranchDoctorAddDto patientAddDto);
    bool Update(BranchDoctorUpdateDto patientUpdateDto);
    void Delete(int id);

}
