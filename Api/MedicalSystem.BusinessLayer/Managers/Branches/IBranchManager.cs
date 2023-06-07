using MedicalSystem.CoreLayer.Dtos.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.BusinessLayer.Managers.Branches
{
    public interface IBranchManager
    {

        public  Task<List<ReadBranchDto>> GetAll();
        public Task<ReadBranchDto?> GetById(int id);

        public int Add(AddBranchDto entity);

        public bool Update(UpdateBranchDto entity);

        public void Delete(int id);



    }
}
