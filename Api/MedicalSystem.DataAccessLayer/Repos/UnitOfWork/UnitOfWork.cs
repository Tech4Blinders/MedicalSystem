namespace MedicalSystem.DataAccessLayer;

internal class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }

    public UnitOfWork(IDoctorRepo doctorRepo, IDoctorQualificationRepo doctorQualificationRepo)
    {
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
    }


}
