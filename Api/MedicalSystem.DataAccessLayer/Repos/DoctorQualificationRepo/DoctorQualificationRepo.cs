using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;


public class DoctorQualificationRepo : GenericRepo<Doctor>, IDoctorQualificationRepo
{
    public DoctorQualificationRepo(ApplicationDbContext context) : base(context) { }

    
}
