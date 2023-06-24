using MedicalSystem.CoreLayer;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.DataAccessLayer;

public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
{
    private readonly ApplicationDbContext _context;
    public DoctorRepo(ApplicationDbContext context) : base(context) 
    { 
        _context = context;
    }

    public IEnumerable<Doctor> getDocByClinicId(int clinicId)
    {
        return _context.Set<Doctor>().Where(a => a.ClinicId == clinicId).Include("Department").Include("Clinic");
    }
}
