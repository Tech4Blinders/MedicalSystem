using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

public class ZoomMeetingManager : IZoomMeetingManager
{
	private readonly IUnitOfWork _unitOfWork;
	public ZoomMeetingManager(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<int>  Add(ZoomMeetingAddDto entity)
	{
		ZoomMeeting newZoomMeeting = new ZoomMeeting
		{
			MeetingId=entity.MeetingId,
			Password=entity.Password,
			Duration=entity.Duration,
			StartTime=entity.StartTime,
		};
		await _unitOfWork._ZoomMeetingRepo.AddAsync(newZoomMeeting);
		_unitOfWork.SaveChanges();
		return newZoomMeeting.Id;
	}
	
	public ZoomMeetingReadDto? GetMeetingByAppointmentID(int id)
	{
		Appointment? appointment = _unitOfWork._AppointmentRepo.GetAppointmentById(id);

		if (appointment == null) return null;

		return new ZoomMeetingReadDto
		{
			Id = appointment.ZoomMeeting!.Id,
			MeetingId = appointment.ZoomMeeting.MeetingId,
			Password = appointment.ZoomMeeting.Password,
			Duration = appointment.ZoomMeeting.Duration,
			StartTime = appointment.ZoomMeeting.StartTime,
		};
	}

}
