using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer
{
    public class ReviewRepo : GenericRepo<Review>, IReviewRepo
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
