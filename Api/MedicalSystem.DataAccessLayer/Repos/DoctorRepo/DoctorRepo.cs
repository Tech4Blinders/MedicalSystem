using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;

public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
{
    public DoctorRepo(ApplicationDbContext context) : base(context) { }

    
}
