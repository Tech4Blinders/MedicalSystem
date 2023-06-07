using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorQualificationController : ControllerBase
    {
        private readonly IDoctorQualificationManager _doctorQualificationManager;

        public DoctorQualificationController(IDoctorQualificationManager doctorQualificationManager)
        {
            _doctorQualificationManager = doctorQualificationManager;
        }
        [HttpGet]
        public  ActionResult<IEnumerable<ReadDoctorQualificationDto>> GetAll() => Ok(_doctorQualificationManager.GetAll());

        [HttpGet("{id}")]
        public  ActionResult<ReadDoctorQualificationDto> GetById(int id)
        {
            var docqualification = _doctorQualificationManager.GetById(id);
            if (docqualification == null)
                return NotFound("This Qulaification is Not Founded");
            return Ok(docqualification);

        }

        [HttpPost]
        public  ActionResult<ReadDoctorQualificationDto> Add(AddDoctorQualificationDto dto)
        {
            return Ok(_doctorQualificationManager.Add(dto));
        }
        [HttpPut]
        public ActionResult Update(UpdateDoctorQualificationDto dto)
        {
            if (!_doctorQualificationManager.Update(dto))
                return BadRequest("Not Updated");
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            if (_doctorQualificationManager.Delete(id))
                return BadRequest("Not Deleted");
            return NoContent();
        }
    }
}
