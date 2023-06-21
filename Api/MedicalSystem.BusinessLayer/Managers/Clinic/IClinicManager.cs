using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer
{
	public interface IClinicManager
	{
		List<ClinicWithIdDto> GetAll();
        List<ClinicWithIdDto> GetClinicsByHosId(int branchId);
        Clinic? GetById(int id);
		int Add(ClinicWithoutIdDto clinicWithoutIdDto);
		bool Update(ClinicWithIdDto clinicWithId);
		void Delete(int id);
	}
}
