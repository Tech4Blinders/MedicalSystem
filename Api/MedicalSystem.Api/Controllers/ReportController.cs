using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public readonly IReportManager _reportManager;
        public ReportController(IReportManager reportManager)
        {
            _reportManager = reportManager;
        }

        [HttpGet]
        public ActionResult<List<ReportReadDto>> GetAllReports()
        {
            var reports = _reportManager.GetAllReports();
            if (reports == null)
            {
                return NoContent();
            }
            return Ok(reports);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReportReadDto> GetReportById(int id)
        {
            var report = _reportManager.GetRepotById(id);
            if (report == null)
            {
                return NoContent();
            }
            return Ok(report);
        }

        [HttpPost]
        public ActionResult AddReport(ReportAddDto reportToAdd)
        {
            int newReportId = _reportManager.AddReport(reportToAdd);
            return CreatedAtAction("GetReportById", new { id = newReportId }, new { m = "Report has been added successfully" });
        }

        [HttpDelete]
        public ActionResult DeleteReport(int id)
        {
            _reportManager.DeleteReport(id);
            return NoContent();
        }

        //[HttpPut]
        //public ActionResult UpdateReport(ReportUpdateDto reportToUpdate)
        //{
        //    bool isFound = _reportManager.UpdateReport(reportToUpdate);
        //    if (isFound)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}
    }
}
