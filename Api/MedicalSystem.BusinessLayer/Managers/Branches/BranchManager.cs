
using MedicalSystem.CoreLayer;
using MedicalSystem.CoreLayer.Dtos.BranchDtos;
using MedicalSystem.CoreLayer.Dtos.ClinicDtos;
using MedicalSystem.CoreLayer.Dtos.DoctorDtos;
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
                Image = entity.Image
            };

            unitOfWork._BranchRepo.AddAsync(newBranch);
            unitOfWork.SaveChanges();
            return newBranch.Id;

        }

        public int AddBranchWithAddres(AddBranchWithAddressDto entity)
        {
            var newAddress = new BranchAddress
            {
                City = entity.City,
                Country = entity.Country,
                PostalCode = entity.PostalCode,
                State = entity.State,
                Street = entity.Street,
            };
            unitOfWork._BranchAddressRepo.AddAsync(newAddress);
            unitOfWork.SaveChanges();
            int id = newAddress.Id;
            var newBranch = new Branch
            {
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                HospitalId = entity.HospitalId,
                Image = entity.Image,
                BranchAddressId = id
            };

            unitOfWork._BranchRepo.AddAsync(newBranch);
            unitOfWork.SaveChanges();
            return newBranch.Id;

        }

        public void Delete(int id)
        {
            var branch = unitOfWork._BranchRepo.GetByIdAsync(id).Result;
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
            var branch = await unitOfWork._BranchRepo.GetWith(null, new string[] { "BranchAddress", "Hospital" });
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
                HospitalName = a.Hospital.Name,
                Image = a.Image
            }); ;



        }

        public HospitalWithBranches GetAllBranches(int hospitalId)
        {
            var branches = unitOfWork._BranchRepo.getBranchesWithClinicsWithDocs(hospitalId);
            return  new HospitalWithBranches
            {
               Id= branches.Id,
               Name = branches.Name,
               branches = branches.Branches.Select(b => new BranchWithClinicWithDocDTO
               {
                   Id = b.Id ,
                   Name = b.Name ,
                   PhoneNumber =b.PhoneNumber ,
                   Image =b.Image ,
                   clinics = b.Clinics.Select(c => new ClinicsWithDoctorDto
                   {
                       id = c.Id,
                       Specilization = c.Specilization,
                       RoomNumber = c.RoomNumber,
                       Description = c.Description,
                       Image = c.Image,
                       Doctors = c.Doctors.Select(d => new DoctorInClinicDto
                       {
                           Id = d.Id,
                           Name = d.Name,
                           City = d.City,
                           Country = d.Country,
                           Gender = d.Gender,
                           Email = d.Email,
                           Street = d.Street,
                           PhoneNumber = d.PhoneNumber,
                           Image = d.Image
                       }).ToList()
                   }).ToList()
               }).ToList()
            };

        }
    }
    }


//Id = a.Id,
//                    Name = a.Name,
//                    branches = a.bran
                //    PhoneNumber = a.PhoneNumber,
                //    Image = a.Image,
                //    clinics = a.Clinics.Select(b => new ClinicsWithDoctorDto
                //    {
                //        id = b.Id,
                //        Specilization = b.Specilization,
                //        RoomNumber = b.RoomNumber,
                //        Description = b.Description,
                //        Image = b.Image,
                //        Doctors = b.Doctors.Select(c => new DoctorInClinicDto
                //        {
                //            Id = c.Id,
                //            Name = c.Name,
                //            City= c.City,
                //            Country=c.Country,                    
                //            Gender= c.Gender,
                //            Email= c.Email,
                //            Street= c.Street,
                //            PhoneNumber = c.PhoneNumber,
                //            Image= c.Image                      
                //        }).ToList()
                //    }).ToList()
                //}).ToList();













