using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer
{
	public class ZoomMeetingRepo : GenericRepo<ZoomMeeting> , IZoomMeetingRepo
	{
		private readonly ApplicationDbContext context;
		public ZoomMeetingRepo(ApplicationDbContext _context) : base(_context)
		{
			context = _context;
		}
	}
}
