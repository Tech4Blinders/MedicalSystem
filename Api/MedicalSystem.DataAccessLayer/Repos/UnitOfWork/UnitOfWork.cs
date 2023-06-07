namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo _DoctorRepo { get; }
    public IDoctorQualificationRepo _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }

    public IBranchDoctorRepo _BranchDoctorRepo { get; }

    public ApplicationDbContext _context;

    public UnitOfWork(IDoctorRepo doctorRepo,
        IDoctorQualificationRepo doctorQualificationRepo,
        IPatientRepo patientRepo,
        IBranchDoctorRepo branchDoctorRepo,
        ApplicationDbContext context)
    {
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
        _PatientRepo = patientRepo;
        _BranchDoctorRepo = branchDoctorRepo;
        _context = context;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
