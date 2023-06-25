using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public interface IZoomMeetingManager
{
	ZoomMeetingReadDto? GetMeetingByAppointmentID(int id);

	Task<int> Add(ZoomMeetingAddDto entity);
}
