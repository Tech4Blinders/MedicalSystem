using MedicalSystem.CoreLayer.Dtos.BranchAddressDtos;
using MedicalSystem.CoreLayer.Dtos.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.BusinessLayer.Managers.BranchAddresses
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
