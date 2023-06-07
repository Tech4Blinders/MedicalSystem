using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer;

public class BranchDoctorRepo : GenericRepo<BranchDoctor>, IBranchDoctorRepo
{
    private readonly ApplicationDbContext _context;
    public BranchDoctorRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
