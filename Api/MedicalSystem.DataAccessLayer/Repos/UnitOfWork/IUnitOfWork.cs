using MedicalSystem.DataAccessLayer.Repos.BranchAddressRepos;
using MedicalSystem.DataAccessLayer.Repos.BranchRepos;

namespace MedicalSystem.DataAccessLayer;

public interface IUnitOfWork
{

    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }
    public IBranchRepo? _BranchRepo { get; }
    public IPatientRepo _PatientRepo { get; }
    public IBranchAddressRepo _BranchAddressRepo { get; }
    int SaveChanges();
}
