using MedicalSystem.Api.Services.UploadImage;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;


namespace MedicalSystem.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientManager _patientManager;
        private readonly IUploadImg uploadImg;
        public PatientController(IPatientManager patientManager,IUploadImg _uploadImg)
        {
            _patientManager = patientManager;
            uploadImg = _uploadImg;
        }

        [HttpGet]
        public ActionResult<List<PatientReadDto>> GetAll()
        {
            var patients = _patientManager.GetAll();
            if (patients.Count == 0)
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
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public ActionResult Add([FromForm] PatientAddDto patientDto)
        {
            if (patientDto.File == null || patientDto.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            patientDto.Image = uploadImg.uploadImg(patientDto.File.FileName, patientDto.File.OpenReadStream());
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
