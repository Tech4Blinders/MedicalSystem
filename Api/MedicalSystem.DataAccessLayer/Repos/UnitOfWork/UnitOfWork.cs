using MedicalSystem.DataAccessLayer.Repos.ReportRepo;

namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo _DoctorRepo { get; }
    public IDoctorQualificationRepo _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }
    public IAppointmentRepo _AppointmentRepo { get; }
    public IReportRepo _ReportRepo { get; }
    public ApplicationDbContext _context;

    public UnitOfWork(IDoctorRepo doctorRepo,
        IDoctorQualificationRepo doctorQualificationRepo,
        IPatientRepo patientRepo,
        IAppointmentRepo appointmentRepo,
        IReportRepo reportRepo,
        ApplicationDbContext context)
    {
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
        _PatientRepo = patientRepo;
        _AppointmentRepo = appointmentRepo;
        _ReportRepo = reportRepo;
        _context = context;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
