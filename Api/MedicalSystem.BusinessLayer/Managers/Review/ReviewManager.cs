using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer
{
	public class ReviewManager : IReviewManager
	{
		private readonly IUnitOfWork _unitOfWork;
		public ReviewManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}



		public int Add(ReviewAddDto review)
		{
			var Review = new Review
			{
				ReviewText = review.ReviewText,
				Rate = review.Rate,
				DoctorId= review.DoctorId,
				PatientId=review.PatientId,

			};
			_unitOfWork._ReviewRepo.AddAsync(Review);
			_unitOfWork.SaveChanges();
			return Review.Id;

		
		}

		public  void Delete(int id)
		{
			var Review =  _unitOfWork._ReviewRepo.GetById(id);
			if (Review is null)
			{
				return;
			}
			_unitOfWork._ReviewRepo.Delete(Review);
			_unitOfWork.SaveChanges();

		}

		public List<ReviewWithIdDto> GetAll()
		{
			IEnumerable<Review> Reviews = _unitOfWork._ReviewRepo.GetAllAsyn().Result;
			if (Reviews is null)
			{
				return new List<ReviewWithIdDto>();
			}

			return Reviews.Select(a => new ReviewWithIdDto
			{
				Id = a.Id,
				ReviewText = a.ReviewText,
				Rate = a.Rate,

			}).ToList();

		}

		public IEnumerable<Review?> GetById(int id)
		{
			var Review = _unitOfWork._ReviewRepo.GetWith(a=>a.DoctorId==id).Result;
			if (Review is null)
				return null;
			return Review;
		}

		public bool Update(ReviewUpdateDto Review)
		{
			var Reviewfromdb = _unitOfWork._ReviewRepo.GetByIdAsync(Review.Id).Result;
			if (Reviewfromdb is null) return false;
			Reviewfromdb.ReviewText = Review.ReviewText;
			Reviewfromdb.Rate = Review.Rate;
			Reviewfromdb.DoctorId = Review.DoctorId;
			Reviewfromdb.PatientId = Review.PatientId;
			_unitOfWork._ReviewRepo.Update(Reviewfromdb);
			_unitOfWork.SaveChanges();

			return true;

		}
	}
}
