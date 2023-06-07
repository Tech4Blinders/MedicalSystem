using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer
{
    public class BranchAddressRepo : GenericRepo<BranchAddress>, IBranchAddressRepo
    {
        private readonly ApplicationDbContext context;
        public BranchAddressRepo(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
