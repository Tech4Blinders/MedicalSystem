using MedicalSystem.DataAccessLayer.Repos.BranchRepos;

namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{

    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }
    public IBranchRepo? _BranchRepo { get; }
    public IPatientRepo? _PatientRepo { get; }
    public ApplicationDbContext _context;

    public UnitOfWork(IDoctorRepo doctorRepo, IDoctorQualificationRepo doctorQualificationRepo , IBranchRepo branchRepo, IPatientRepo patientRepo,
        ApplicationDbContext context)
    {
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
        _BranchRepo = branchRepo;
        _PatientRepo = patientRepo;
        _context = context;

    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
