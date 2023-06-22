

using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer
{
    public interface IBranchManager
    {

        public Task<List<ReadBranchDto>> GetAll();
        public Task<ReadBranchDto?> GetById(int id);

        public int Add(AddBranchDto entity);

        public bool Update(UpdateBranchDto entity);

        public void Delete(int id);
        public Task<IEnumerable<BranchWithAddressReadDto?>> GetByIdWithAddress();



    }
}
