using MedicalSystem.CoreLayer;

namespace MedicalSystem.BusinessLayer;

public interface IReportManager
{
    List<ReportReadDto> GetAllReports();
    ReportReadDto? GetRepotById(int id);
    int AddReport(ReportAddDto reportToAdd);
    bool UpdateReport(ReportUpdateDto reportToUpdate);
    Task<bool> DeleteReport(int id);
}
