using MedicalSystem.DataAccessLayer.Repos.BranchRepos;

namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }
    public ApplicationDbContext _context;
    public IBranchRepo _BranchRepo { get; }

    public UnitOfWork(IDoctorRepo doctorRepo, IDoctorQualificationRepo doctorQualificationRepo,
        IPatientRepo patientRepo,
        ApplicationDbContext context,IBranchRepo branchRepo)
    {
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
        _PatientRepo = patientRepo;
        _context = context;
        _BranchRepo = branchRepo;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
