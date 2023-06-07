using MedicalSystem.DataAccessLayer.Repos.BranchAddressRepos;
using MedicalSystem.DataAccessLayer.Repos.BranchRepos;

namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }
    public ApplicationDbContext _context;
    public IBranchRepo _BranchRepo { get; }
    public IBranchAddressRepo _BranchAddressRepo { get; }
    public UnitOfWork(IDoctorRepo doctorRepo, IDoctorQualificationRepo doctorQualificationRepo,
        IPatientRepo patientRepo,
        ApplicationDbContext context,IBranchRepo branchRepo,IBranchAddressRepo branchAddressRepo)
    {
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
        _PatientRepo = patientRepo;
        _context = context;
        _BranchRepo = branchRepo;
        _BranchAddressRepo = branchAddressRepo;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
