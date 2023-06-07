using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorManager _doctorManager;

        public DoctorController(IDoctorManager doctorManager)
        {
            _doctorManager = doctorManager;
        }
        [HttpGet]
        public  ActionResult<IEnumerable<ReadDoctorDto>> GetAll() =>  Ok(_doctorManager.GetAll());

        [HttpGet("{id}")]
        public  ActionResult<ReadDoctorDto> GetById(int id)
        {
            var doctor =  _doctorManager.GetById(id);
            if (doctor == null) return NotFound("Doctor Is Not Found");
            return Ok(doctor);
        }
        [HttpPost]
        public  ActionResult<ReadDoctorDto> Add(AddDoctorDto doctorDto)
        {
            return Ok(_doctorManager.Add(doctorDto));
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isdeleted = _doctorManager.Delete(id);
            if (isdeleted == false)
                return BadRequest("Not Deleted");
            return Ok("Deleted");
        }
        [HttpPut]
        public ActionResult Update(UpdateDoctorDto doctorDto)
        {

            if (!_doctorManager.Update(doctorDto))
            {
                return BadRequest("Not Updated");
            }
            return Ok("Updated");

        }
    }
}
