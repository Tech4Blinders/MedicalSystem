using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer;

namespace MedicalSystem.BusinessLayer;

public class ReportManager : IReportManager
{
    private readonly IUnitOfWork _unitOfWork;
    public ReportManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int AddReport(ReportAddDto reportToAdd)
    {
        Report newReport = new Report
        {
            Description = reportToAdd.Description,
            Prescription = reportToAdd.Prescription,
            Date = reportToAdd.Date,
            AppointmentId = reportToAdd.AppointmentId,
        };
        _unitOfWork._ReportRepo.AddAsync(newReport);
        _unitOfWork.SaveChanges();
        return newReport.Id;
    }

    public async Task<bool> DeleteReport(int id)
    {
        Report? reportToDelete = await _unitOfWork._ReportRepo.GetByIdAsync(id);
        if (reportToDelete == null)
        {
            return false;
        }
        _unitOfWork._ReportRepo.Delete(reportToDelete);
        return true;
    }

    public List<ReportReadDto> GetAllReports()
    {
        IEnumerable<Report>? reports = _unitOfWork._ReportRepo.GetAllReports();
        if (reports == null)
        {
            return new List<ReportReadDto>();
        }
        return reports.Select(report => new ReportReadDto
        {
            Id = report.Id,
            Description = report.Description,
            Prescription = report.Prescription,
            Date = report.Date,
            Appointment = new ReportAppointmentReadDto
            {
                Id = report.Appointment.Id,
                Date = report.Appointment.AppointmentDate,
                Cost = report.Appointment.Cost,

            }
        }).ToList();
    }

    public ReportReadDto? GetRepotById(int id)
    {
        Report? report = _unitOfWork._ReportRepo.GetReportById(id);
        if(report == null)
        {
            return new ReportReadDto();
        }
        return new ReportReadDto
        {
            Id = report.Id,
            Description = report.Description,
            Prescription = report.Prescription,
            Date = report.Date,
            Appointment = new ReportAppointmentReadDto
            {
                Id = report.Appointment.Id,
                Date = report.Appointment.AppointmentDate,
                Cost = report.Appointment.Cost,
            }
        };
    }

    public bool UpdateReport(ReportUpdateDto reportToUpdate)
    {
        throw new NotImplementedException();
    }
}
