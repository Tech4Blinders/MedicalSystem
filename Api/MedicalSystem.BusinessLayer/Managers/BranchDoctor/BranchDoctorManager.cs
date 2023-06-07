using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

public class BranchDoctorManager : IBranchDoctorManager

{
    private readonly IUnitOfWork _unitOfWork;
    public BranchDoctorManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public int Add(BranchDoctorAddDto branchDoctorAddDto)
    {
        var newBranchDoctor = new BranchDoctor
        {
            BranchId=branchDoctorAddDto.BranchId,
            DoctorId=branchDoctorAddDto.DoctorId,
            StaringDate=branchDoctorAddDto.StaringDate,
        };
        _unitOfWork._BranchDoctorRepo.AddAsync(newBranchDoctor);
        _unitOfWork.SaveChanges();
        return newBranchDoctor.BranchId;
    }

    public async void Delete(int id)
    {
        var doctor=await _unitOfWork._BranchDoctorRepo.GetByIdAsync(id);
        if(doctor is null) { return; }
        _unitOfWork._BranchDoctorRepo.Delete(doctor);
    }

    public List<BranchDoctorReadDto> GetAll()
    {
        IEnumerable<BranchDoctor> branchdoctors = _unitOfWork._BranchDoctorRepo.GetAllAsyn().Result;
        if (branchdoctors is null)
        {
            return new List<BranchDoctorReadDto>();
        }

        return branchdoctors.Select(a => new BranchDoctorReadDto
        {
            BranchId=a.BranchId,
            DoctorId=a.DoctorId,
            StaringDate=a.StaringDate,

        }).ToList();
    }

    public BranchDoctor? GetById(int id)
    {
        var branchdoctors = _unitOfWork._BranchDoctorRepo.GetByIdAsync(id).Result;
        if (branchdoctors is null)
            return null;
        return branchdoctors;
    }

    public bool Update(BranchDoctorUpdateDto branchDoctorUpdateDto)
    {
        var branchdoctorfromDb = _unitOfWork._BranchDoctorRepo.GetByIdAsync(branchDoctorUpdateDto.DoctorId).Result;
        if (branchdoctorfromDb is null) return false;
        branchdoctorfromDb.BranchId=branchDoctorUpdateDto.BranchId;
        branchdoctorfromDb.StaringDate = branchDoctorUpdateDto.StaringDate;
        _unitOfWork.SaveChanges();
        return true;
    }
}

