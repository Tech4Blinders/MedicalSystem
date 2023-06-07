using MedicalSystem.CoreLayer;
using MedicalSystem.DataAccessLayer.Repos.ReportRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        return _context.Set<Report>().FirstOrDefault(report => report.Id == id);
    }
}
