using MedicalSystem.CoreLayer;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.DataAccessLayer;

public class ReportRepo : GenericRepo<Report>, IReportRepo
{
    public readonly ApplicationDbContext _context;
    public ReportRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Report>? GetAllReports()
    {
        return _context.Set<Report>()
            .Include(report => report.Appointment)
            .ToList();
    }

    public Report? GetReportById(int id)
    {
        return _context.Set<Report>()
            .Include(a => a.Appointment)
            .FirstOrDefault(report => report.Id == id);
    }
}
