
using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer
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
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                HospitalId = entity.HospitalId,
                BranchAddressId = entity.BranchAddressId,
                Image = entity.Image 
            };

            unitOfWork._BranchRepo.AddAsync(newBranch);
            unitOfWork.SaveChanges();
            return newBranch.Id;

        }

        public  void Delete(int id)
        {
            var branch =  unitOfWork._BranchRepo.GetByIdAsync(id).Result;
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
                Id = a.Id,
                Name = a.Name,
                PhoneNumber = a.PhoneNumber,
                HospitalId = a.HospitalId,
                BranchAddressId = a.BranchAddressId,
                Image = a.Image 
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



        public bool Update(UpdateBranchDto entity)
        {
            var branch = unitOfWork._BranchRepo.GetByIdAsync(entity.Id).Result;
            if (branch == null)
            {
                return false;
            }
            branch.Name = entity.Name;
            branch.PhoneNumber = entity.PhoneNumber;
            unitOfWork.SaveChanges();
            return true;
        }
        public async Task<IEnumerable<BranchWithAddressReadDto?>> GetByIdWithAddress()
        {
            var branch = await unitOfWork._BranchRepo.GetWith( null,new string[] { "BranchAddress","Hospital" });
            if (branch == null)
            {
                return new List<BranchWithAddressReadDto>().DefaultIfEmpty();
            }
            return branch.Select(a => new BranchWithAddressReadDto
            {
                Id = a.Id,
                Name = a.Name,
                PhoneNumber = a.PhoneNumber,
                City = a.BranchAddress.City,
                Country = a.BranchAddress.Country,
                HospitalId = a.HospitalId,
                HospitalName=a.Hospital.Name,
                Image = a.Image
            });;
            


        }



    }
}














