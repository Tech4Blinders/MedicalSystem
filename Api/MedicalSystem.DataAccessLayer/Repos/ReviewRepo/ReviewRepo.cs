using MedicalSystem.CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.DataAccessLayer
{
	public class ReviewRepo : GenericRepo<Review>,IReviewRepo
	{
        private readonly ApplicationDbContext _context;
        public ReviewRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
            
        }
    }
}
