using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer
{
	public interface IReviewManager
	{
		List<ReviewWithIdDto> GetAll();
		Review? GetById(int id);
		int Add(ReviewAddDto Review);
		bool Update(ReviewUpdateDto Review);
		void Delete(int id);
	}
}
