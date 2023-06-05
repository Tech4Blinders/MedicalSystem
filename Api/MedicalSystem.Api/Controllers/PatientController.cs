using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientManager _patientManager;

        public PatientController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [HttpGet]
        public ActionResult<List<PatientReadDto>> GetAll()
        {
            var patients= _patientManager.GetAll();
            if(patients.Count==0)
            {
                return NoContent();
            }
            return Ok(patients);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public ActionResult<PatientReadDto> Get(int id)
        {
            var patient = _patientManager.GetById(id);
            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public ActionResult Add(PatientAddDto patientDto)
        {
            var newId = _patientManager.Add(patientDto);
            return CreatedAtAction("GetById", new { id = newId }, new { m = "patient has been added successfully" });

        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public ActionResult Update(PatientUpdateDto patientDto)
        {
            var isFound = _patientManager.Update(patientDto);
            if (!isFound)
            {
                return NotFound();
            }

            return NoContent(); 
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            _patientManager.Delete(id);
            return NoContent();
        }
    }
}
