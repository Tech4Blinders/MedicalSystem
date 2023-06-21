using MedicalSystem.CoreLayer;
namespace MedicalSystem.DataAccessLayer;

public interface IDoctorRepo : IGenericRepo<Doctor>
{
    IEnumerable<Doctor> getDocByClinicId(int clinicId);
}
