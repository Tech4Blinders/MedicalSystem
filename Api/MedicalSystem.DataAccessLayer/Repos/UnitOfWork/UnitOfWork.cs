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

    public UnitOfWork(IDoctorRepo doctorRepo,
        IDoctorQualificationRepo doctorQualificationRepo,
        IPatientRepo patientRepo,
        IBranchDoctorRepo branchDoctorRepo,
        IAppointmentRepo appointmentRepo,
        IReportRepo reportRepo,
        ApplicationDbContext context)
    {
        _context = context;
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
        _PatientRepo = patientRepo;
        _BranchDoctorRepo = branchDoctorRepo;
        _AppointmentRepo = appointmentRepo;
        _ReportRepo = reportRepo;
        
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
