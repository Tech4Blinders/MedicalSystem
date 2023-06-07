using MedicalSystem.CoreLayer;
using MedicalSystem.CoreLayer.Dtos.BranchDtos;
using MedicalSystem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.BusinessLayer.Managers.Branches
{
    public class BranchManager : IBranchManager
    {
        private IUnitOfWork unitOfWork;
        public BranchManager(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public int Add(AddBranchDto entity)
        {
            var newBranch = new Branch
            {
                Id = entity.Id
                ,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                HospitalId = entity.HospitalId,
                BranchAddressId = entity.BranchAddressId
            };

            unitOfWork._BranchRepo.AddAsync(newBranch);
            unitOfWork.SaveChanges();
            return newBranch.Id;
            
        }

        public async void Delete(int id)
        {
            var branch = await unitOfWork._BranchRepo.GetByIdAsync(id);
            if (branch == null)
            {
                return;
            }
            else
            {
                unitOfWork._BranchRepo.Delete(branch);
                unitOfWork.SaveChanges();
            }
            
        }

        public async Task<List<ReadBranchDto>> GetAll()
        {
            var branches = await unitOfWork._BranchRepo.GetAllAsyn();
            return branches.Select(a => new ReadBranchDto
            {
                Id= a.Id ,
                Name = a.Name,
                PhoneNumber = a.PhoneNumber ,
                HospitalId = a.HospitalId ,
                BranchAddressId = a.BranchAddressId 
            }).ToList();
        }

        public async Task<ReadBranchDto?> GetById(int id)
        {
            var branch = await unitOfWork._BranchRepo.GetByIdAsync(id);
            if (branch == null)
            {
                return null;
            }
            return new ReadBranchDto
            {
                Id = branch.Id,
                Name = branch.Name,
                PhoneNumber = branch.PhoneNumber,
                HospitalId = branch.HospitalId,
                BranchAddressId = branch.BranchAddressId
            };
        }

      

        public  bool Update(UpdateBranchDto entity)
        {
            var branch =  unitOfWork._BranchRepo.GetByIdAsync(entity.Id).Result;
            if (branch == null)
            {
                return false;
            }
            branch.Name = entity.Name;
            branch.PhoneNumber = entity.PhoneNumber;
            unitOfWork.SaveChanges();
            return true;
        }
      
    }
}














