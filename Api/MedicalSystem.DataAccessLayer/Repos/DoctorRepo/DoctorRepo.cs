using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;

public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
{
    private readonly ApplicationDbContext _context;
    public DoctorRepo(ApplicationDbContext context) : base(context) 
    { 
        _context = context;
    }

    
}
