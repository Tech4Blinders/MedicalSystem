using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer
{
    public class BranchRepo : GenericRepo<Branch>, IBranchRepo
    {
        private readonly ApplicationDbContext context;
        public BranchRepo(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
