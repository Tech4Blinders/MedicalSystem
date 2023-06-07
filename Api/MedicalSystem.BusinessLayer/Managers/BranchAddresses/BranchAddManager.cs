using MedicalSystem.CoreLayer;
using MedicalSystem.CoreLayer.Dtos.BranchAddressDtos;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer
{
    public class BranchAddManager : IBranchAddManager
    {
        private readonly IUnitOfWork unitOfWork;
        public BranchAddManager(IUnitOfWork _uitOfWork)
        {
            unitOfWork = _uitOfWork;
        }
        public int Add(AddBranchAddressDto entity)
        {
            var branchAdd = new BranchAddress
            {
                PostalCode = entity.PostalCode,
                Street = entity.Street,
                City = entity.City,
                Country = entity.Country,
                State = entity.State
            };
            unitOfWork._BranchAddressRepo.AddAsync(branchAdd);
            unitOfWork.SaveChanges();
            return branchAdd.Id;
        }

        public void Delete(int id)
        {
            var branchAdd = unitOfWork._BranchAddressRepo.GetByIdAsync(id).Result;
            if (branchAdd == null)
            {
                return;
            }
            else
            {
                unitOfWork._BranchAddressRepo.Delete(branchAdd);
                unitOfWork.SaveChanges();
            }
        }

        public async Task<List<ReadBranchAddressDto>> GetAll()
        {
            var branches = await unitOfWork._BranchAddressRepo.GetAllAsyn();
            return branches.Select(a => new ReadBranchAddressDto
            {
                Id = a.Id,
                PostalCode = a.PostalCode,
                Street = a.Street,
                City = a.City,
                Country = a.Country,
                State = a.State
            }).ToList();
        }

        public async Task<ReadBranchAddressDto?> GetById(int id)
        {
            var branch = await unitOfWork._BranchAddressRepo.GetByIdAsync(id);
            if (branch == null)
            {
                return null;
            }
            return new ReadBranchAddressDto
            {
                Id = branch.Id,
                PostalCode = branch.PostalCode,
                Street = branch.Street,
                City = branch.City,
                Country = branch.Country,
                State = branch.State
            };
        }

        public bool Update(UpdateBranchAddressDto entity)
        {
            var branch = unitOfWork._BranchAddressRepo.GetByIdAsync(entity.Id).Result;
            if (branch == null)
            {
                return false;
            }
            branch.PostalCode = entity.PostalCode;
            branch.Street = entity.Street;
            branch.City = entity.City;
            branch.State = entity.State;
            branch.Country = entity.Country;
            unitOfWork.SaveChanges();
            return true;
        }
    }
}

