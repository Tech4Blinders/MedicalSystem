using MedicalSystem.Api.Services.UploadImage;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicManager _ClinicManager;
        private readonly IUploadImg uploadImg;

        public ClinicController(IClinicManager ClinicManager, IUploadImg _uploadImg)
        {
            _ClinicManager = ClinicManager;
            uploadImg = _uploadImg;
        }

        [HttpGet]
        public ActionResult<List<ClinicWithIdDto>> GetAll()
        {
            var Clinics = _ClinicManager.GetAll();
            if (Clinics.Count == 0)
            {
                return NoContent();
            }
            return Ok(Clinics);
        }

        // GET api/<ClinicController>/5
        [HttpGet("{id}")]
        public ActionResult<ClinicWithIdDto> Get(int id)
        {
            var Clinic = _ClinicManager.GetById(id);
            if (Clinic == null)
            {
                return NotFound();
            }
            return Ok(Clinic);
        }
        // clinics in specific hospital
        [HttpGet("HospitalClinics/{id}")]
        public ActionResult<ClinicWithIdDto> GetClinicsInHospital(int id)
        {
            var Clinic = _ClinicManager.GetClinicsByHosId(id);
            if (Clinic == null)
            {
                return NotFound();
            }
            return Ok(Clinic);
        }

        [HttpPost]
        public ActionResult<int> Add([FromForm] ClinicWithoutIdDto ClinicDto)
        {
            if (ClinicDto.File == null || ClinicDto.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            ClinicDto.Image = uploadImg.uploadImg(ClinicDto.File.FileName, ClinicDto.File.OpenReadStream());
            var newId = _ClinicManager.Add(ClinicDto);
            return Ok(newId);
            /*return CreatedAtAction("GetById", new { id = newId }, new { m = "Clinic has been added successfully" });*/

        }

        // PUT api/<ClinicController>/5
        [HttpPut]
        public ActionResult Update([FromForm] ClinicWithIdDto ClinicDto)
        {
            if (ClinicDto.File == null || ClinicDto.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            ClinicDto.Image = uploadImg.uploadImg(ClinicDto.File.FileName, ClinicDto.File.OpenReadStream());
            var isFound = _ClinicManager.Update(ClinicDto);
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
            _ClinicManager.Delete(id);
            return NoContent();
        }
    }
}
