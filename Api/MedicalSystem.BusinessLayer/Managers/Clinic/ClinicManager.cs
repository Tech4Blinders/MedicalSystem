﻿using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer
{
	public class ClinicManager : IClinicManager
	{
		private readonly IUnitOfWork _unitOfWork;
		public ClinicManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}



		public int Add(ClinicWithoutIdDto clinicWithoutIdDto)
		{
			var clinic = new Clinic
			{
				Specilization=clinicWithoutIdDto.Specilization,
				Description=clinicWithoutIdDto.Description,
				RoomNumber=clinicWithoutIdDto.RoomNumber,
				Image = clinicWithoutIdDto.Image ,
				BranchId= clinicWithoutIdDto.BranchId
			};
			_unitOfWork._ClinicRepo.AddAsync(clinic);
			_unitOfWork.SaveChanges();
			return clinic.Id;
		}

		public void Delete(int id)
		{
			var clinic =  _unitOfWork._ClinicRepo.GetById(id);
			if (clinic is null)
			{
				return;
			}
			_unitOfWork._ClinicRepo.Delete(clinic);
			_unitOfWork.SaveChanges();
		}
		//public async void Delete(int id)
		//{
		//	var clinic = await _unitOfWork._ClinicRepo.GetByIdAsync(id);
		//	if (clinic is null)
		//	{
		//		return;
		//	}
		//	_unitOfWork._ClinicRepo.Delete(clinic);

		//}


		public List<ClinicWithIdDto> GetAll()
		{
			IEnumerable<Clinic> clinics = _unitOfWork._ClinicRepo.GetAllAsyn().Result;
			if (clinics is null)
			{
				return new List<ClinicWithIdDto>();
			}

			return clinics.Select(a => new ClinicWithIdDto
			{
				Id = a.Id,
				Specilization = a.Specilization,
				Description=a.Description,
				RoomNumber=a.RoomNumber,
				Image= a.Image

			}).ToList();

		}

		public ClinicWithIdDto? GetById(int id)
		{
			var clinic = _unitOfWork._ClinicRepo.GetByIdAsync(id).Result;
			var newClinic = new ClinicWithIdDto
			{
				Id = clinic.Id,
				Specilization = clinic.Specilization,
				Description = clinic.Description,
				RoomNumber = clinic.RoomNumber,
				Image = clinic.Image
			};
			if (clinic is null)
				return null;
			return newClinic;
		}

        public List<ClinicWithIdDto> GetClinicsByHosId(int branchId)
        {
            IEnumerable<Clinic> clinics = _unitOfWork._ClinicRepo.getClinicsByHosId(branchId);
            if (clinics is null)
            {
                return new List<ClinicWithIdDto>();
            }

            return clinics.Select(a => new ClinicWithIdDto
            {
                Id = a.Id,
                Specilization = a.Specilization,
                Description = a.Description,
                RoomNumber = a.RoomNumber,
                Image = a.Image

            }).ToList();
        }

        public bool Update(ClinicWithIdDto clinicWithIdDto)
		{
			var clinicfromdb = _unitOfWork._ClinicRepo.GetByIdAsync(clinicWithIdDto.Id).Result;
			if (clinicfromdb is null) return false;
			clinicfromdb.Specilization = clinicWithIdDto.Specilization;
			clinicfromdb.Description = clinicWithIdDto.Description;
			clinicfromdb.RoomNumber = clinicWithIdDto.RoomNumber;
			_unitOfWork._ClinicRepo.Update(clinicfromdb);
			_unitOfWork.SaveChanges();

			return true;

		}

       
    }
}
