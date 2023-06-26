

using MedicalSystem.CoreLayer;
using MedicalSystem.CoreLayer.Dtos.BranchDtos;

namespace MedicalSystem.BusinessLayer
{
    public interface IBranchManager
    {

        public Task<List<ReadBranchDto>> GetAll();
        public HospitalWithBranches GetAllBranches(int hospitalId);
        public Task<ReadBranchDto?> GetById(int id);

        public int Add(AddBranchDto entity);
        public int AddBranchWithAddres(AddBranchWithAddressDto entity);
        public bool Update(UpdateBranchDto entity);

        public void Delete(int id);
        public Task<IEnumerable<BranchWithAddressReadDto?>> GetByIdWithAddress();



    }
}
