using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;

public class PatientRepo : GenericRepo<Patient>,IPatientRepo
{
    private readonly ApplicationDbContext _context;

    public PatientRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }


}
