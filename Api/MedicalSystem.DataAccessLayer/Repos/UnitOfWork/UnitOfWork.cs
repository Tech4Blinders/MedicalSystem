using MedicalSystem.DataAccessLayer.Repos.ReportRepo;

namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo _DoctorRepo { get; }
    public IDoctorQualificationRepo _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }

    public IBranchDoctorRepo _BranchDoctorRepo { get; }

    public IAppointmentRepo _AppointmentRepo { get; }
    public IReportRepo _ReportRepo { get; }
    public ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _DoctorRepo = new DoctorRepo(_context);
        _DoctorQualificationRepo = new DoctorQualificationRepo(_context);
        _PatientRepo = new PatientRepo(_context);
        _BranchDoctorRepo = new BranchDoctorRepo(_context);
        _AppointmentRepo = new AppointmentRepo(_context);
        _ReportRepo = new ReportRepo(_context);
        
        
    }
    

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
