using MedicalSystem.DataAccessLayer.Repos.BranchRepos;

namespace MedicalSystem.DataAccessLayer;

public interface IUnitOfWork
{
    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }
    public IBranchRepo? _BranchRepo { get; }

    int SaveChanges();
}
