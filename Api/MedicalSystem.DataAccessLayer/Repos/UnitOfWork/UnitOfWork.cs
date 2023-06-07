
namespace MedicalSystem.DataAccessLayer;

public class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo _DoctorRepo { get; private set; }
    public IDoctorQualificationRepo _DoctorQualificationRepo { get; private set; }
    public IPatientRepo _PatientRepo { get; private set; }
    public IClinicRepo _ClinicRepo { get; private set; }
    public IReviewRepo _ReviewRepo { get; private set; }
    public ApplicationDbContext _context;

    public UnitOfWork(/*IDoctorRepo doctorRepo,
        IDoctorQualificationRepo doctorQualificationRepo,
        IPatientRepo patientRepo,
        IClinicRepo clinicRepo,
        IReviewRepo reviewRepo,*/
        ApplicationDbContext context)
    {

        _context = context;
        _DoctorRepo = new DoctorRepo(_context);
		_DoctorQualificationRepo = new DoctorQualificationRepo(_context);
		_PatientRepo = new PatientRepo(_context);
		_ClinicRepo = new ClinicRepo(_context);
		_ReviewRepo = new ReviewRepo(_context);
        

        //_DoctorRepo = doctorRepo;
        //_DoctorQualificationRepo = doctorQualificationRepo;
        //_PatientRepo = patientRepo;
        //_ClinicRepo= clinicRepo;
        //_ReviewRepo= reviewRepo;
        //_context = context;
    }

	public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
