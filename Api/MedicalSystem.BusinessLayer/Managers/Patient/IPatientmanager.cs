using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public interface IPatientManager
{
    List<PatientReadDto> GetAll();
    Patient? GetById(int id);
    int Add(PatientAddDto patientAddDto);
    bool Update(PatientUpdateDto patientUpdateDto);
    void Delete(int id);
    
}
