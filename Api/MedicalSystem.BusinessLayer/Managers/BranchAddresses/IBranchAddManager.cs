using MedicalSystem.CoreLayer.Dtos.BranchAddressDtos;

namespace MedicalSystem.BusinessLayer
{
    public interface IBranchAddManager
    {
        public Task<List<ReadBranchAddressDto>> GetAll();
        public Task<ReadBranchAddressDto?> GetById(int id);

        public int Add(AddBranchAddressDto entity);

        public bool Update(UpdateBranchAddressDto entity);

        public void Delete(int id);
    }
}
