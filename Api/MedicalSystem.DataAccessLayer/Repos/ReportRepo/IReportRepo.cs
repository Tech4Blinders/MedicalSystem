using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer.Repos.ReportRepo
{
    public interface IReportRepo : IGenericRepo<Report>
    {
        List<Report>? GetAllReports();
        Report? GetReportById(int id);
    }
}
