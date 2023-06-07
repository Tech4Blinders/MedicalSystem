using MedicalSystem.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Repos.BranchAddressRepos
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
