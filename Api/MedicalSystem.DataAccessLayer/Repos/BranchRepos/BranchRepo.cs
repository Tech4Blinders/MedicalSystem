using MedicalSystem.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer.Repos.BranchRepos
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
