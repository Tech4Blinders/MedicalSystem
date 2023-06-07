
namespace MedicalSystem.DataAccessLayer;

public interface IUnitOfWork
{
    public IDoctorRepo _DoctorRepo { get; }
    public IDoctorQualificationRepo _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }
    public IBranchDoctorRepo _BranchDoctorRepo { get; }
    public IAppointmentRepo _AppointmentRepo { get; }
    public IReportRepo _ReportRepo { get; }
    public IClinicRepo _ClinicRepo { get; }
    public IReviewRepo _ReviewRepo { get; }
    int SaveChanges();
}
