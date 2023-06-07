using MedicalSystem.DataAccessLayer.Repos.BranchRepos;

namespace MedicalSystem.DataAccessLayer;

internal class UnitOfWork : IUnitOfWork
{
    public IDoctorRepo? _DoctorRepo { get; }
    public IDoctorQualificationRepo? _DoctorQualificationRepo { get; }
    public IBranchRepo? _BranchRepo { get; }

    public UnitOfWork(IDoctorRepo doctorRepo, IDoctorQualificationRepo doctorQualificationRepo , IBranchRepo branchRepo)
    {
        _DoctorRepo = doctorRepo;
        _DoctorQualificationRepo = doctorQualificationRepo;
        _BranchRepo = branchRepo;
    }


}
