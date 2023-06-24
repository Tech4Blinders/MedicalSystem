using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MedicalSystem.Api.Services.UploadImage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorManager _doctorManager;
        private readonly IUploadImg upload_img;

        public DoctorController(IDoctorManager doctorManager ,IUploadImg _upload)
        {
            _doctorManager = doctorManager;
            upload_img  = _upload;
          
        }
        [HttpGet]
        public ActionResult<IEnumerable<ReadDoctorDto>> GetAll()
        {
            string[] includedModel = { "DoctorQualification" };
           return Ok(_doctorManager.GetAll()); 
        }

        [HttpGet("{id}")]
        public  ActionResult<ReadDoctorDto> GetById(int id)
        {
            var doctor =  _doctorManager.GetById(id);
            if (doctor == null) return NotFound("Doctor Is Not Found");
            return Ok(doctor);
        }
        [HttpGet("clinic/{id}")]
        public ActionResult<IEnumerable<ReadDoctorDto>> GetByClinicId(int id)
        {
            var doctors = _doctorManager.GetDocByClinicId(id);
            
            return Ok(doctors);
        }
        [HttpPost]
        public async Task<ActionResult<ReadDoctorDto>>  Add([FromForm] AddDoctorDto doctorDto)
        {
            if (doctorDto.File == null || doctorDto.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            doctorDto.Image= upload_img.uploadImg(doctorDto.File.FileName,doctorDto.File.OpenReadStream());
            return await _doctorManager.Add(doctorDto);
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
