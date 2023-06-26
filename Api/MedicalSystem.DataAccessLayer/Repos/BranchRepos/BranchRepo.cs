using MedicalSystem.CoreLayer;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.DataAccessLayer
{
    public class BranchRepo : GenericRepo<Branch>, IBranchRepo
    {
        private readonly ApplicationDbContext context;
        public BranchRepo(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        public Hospital getBranchesWithClinicsWithDocs(int id)
        {
            //return context.Set<Branch>().Where(b => b.HospitalId == id).Include(b => b.Clinics).ThenInclude(b => b.Doctors) ;
            return context.Set<Hospital>().Where(b => b.Id == id).Include(b => b.Branches).ThenInclude(c => c.Clinics).ThenInclude(d => d.Doctors).FirstOrDefault();
        }
    }
}
