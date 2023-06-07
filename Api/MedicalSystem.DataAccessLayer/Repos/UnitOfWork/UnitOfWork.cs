using MedicalSystem.DataAccessLayer.Repos.BranchAddressRepos;
using MedicalSystem.DataAccessLayer.Repos.BranchRepos;

namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }

    public IBranchDoctorRepo _BranchDoctorRepo { get; }

    public IAppointmentRepo _AppointmentRepo { get; }
    public IReportRepo _ReportRepo { get; }

    public IClinicRepo _ClinicRepo { get; }

    public IReviewRepo _ReviewRepo { get; }

    public ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    public IBranchRepo _BranchRepo { get; }
    public IBranchAddressRepo _BranchAddressRepo { get; }
    public UnitOfWork(IDoctorRepo doctorRepo, IDoctorQualificationRepo doctorQualificationRepo,
        IPatientRepo patientRepo,
        ApplicationDbContext context,IBranchRepo branchRepo,IBranchAddressRepo branchAddressRepo)
    {
        _context = context;
        _DoctorRepo = new DoctorRepo(_context);
        _DoctorQualificationRepo = new DoctorQualificationRepo(_context);
        _PatientRepo = new PatientRepo(_context);
        _BranchDoctorRepo = new BranchDoctorRepo(_context);
        _AppointmentRepo = new AppointmentRepo(_context);
        _ReportRepo = new ReportRepo(_context);
        _ClinicRepo = new ClinicRepo(_context);
        _ReviewRepo = new ReviewRepo(_context);

        _BranchRepo = branchRepo;
        _BranchAddressRepo = branchAddressRepo;
    }


    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
