using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer
{
    public interface IBranchRepo : IGenericRepo<Branch>
    {
        public Hospital getBranchesWithClinicsWithDocs(int id);
    }
}
