using MedicalSystem.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer;

public class ClinicRepo:GenericRepo<Clinic>,IClinicRepo
{
	private readonly ApplicationDbContext _context;

	public ClinicRepo(ApplicationDbContext context):base(context)
        {
		_context = context;
        }

    public IEnumerable<Clinic> getClinicsByHosId(int branchId)
    {
        return _context.Set<Clinic>().Where(a => a.BranchId == branchId);
    }
}
