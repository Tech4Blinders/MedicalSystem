using MedicalSystem.CoreLayer;

namespace MedicalSystem.DataAccessLayer
{
    public interface IReportRepo : IGenericRepo<Report>
    {
        List<Report>? GetAllReports();
        Report? GetReportById(int id);
    }
}
