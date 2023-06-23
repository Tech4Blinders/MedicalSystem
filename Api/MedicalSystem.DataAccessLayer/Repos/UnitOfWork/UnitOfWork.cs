namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo _DoctorRepo { get; }
    public IDoctorQualificationRepo _DoctorQualificationRepo { get; }
    public IPatientRepo _PatientRepo { get; }

    public IBranchDoctorRepo _BranchDoctorRepo { get; }

    public IAppointmentRepo _AppointmentRepo { get; }
    public IReportRepo _ReportRepo { get; }

    public IClinicRepo _ClinicRepo { get; }

    public IReviewRepo _ReviewRepo { get; }

    public ApplicationDbContext _context;
    public IBranchRepo _BranchRepo { get; }
    public IBranchAddressRepo _BranchAddressRepo { get; }

    public IAvaliableAppointmentRepo _AvaliableAppointmentRepo { get; }
	public IZoomMeetingRepo _ZoomMeetingRepo { get; }


	public UnitOfWork(ApplicationDbContext context)
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
        _AvaliableAppointmentRepo=new AvaliableAppointmentRepo(_context);
        _BranchRepo = new BranchRepo(_context);
        _BranchAddressRepo = new BranchAddressRepo(_context);
        _ZoomMeetingRepo = new ZoomMeetingRepo(_context);

	}


    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
