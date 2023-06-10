using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorManager _doctorManager;
        private readonly IConfiguration _config;

        public DoctorController(IDoctorManager doctorManager , IConfiguration config)
        {
            _doctorManager = doctorManager;
            _config = config;
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
        public async Task<ActionResult<ReadDoctorDto>>  Add([FromForm] AddDoctorDto doctorDto)
        {
            if (doctorDto.File == null || doctorDto.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }
            var cloudinaryCloudName = _config.GetValue<string>("cloudinaryCloudName");
            var cloudinaryApiKey = _config.GetValue<string>("cloudinaryApiKey");
            var cloudinaryApiSecret = _config.GetValue<string>("cloudinaryApiSecret");
            //var cloudinaryURL = _config.GetValue<string>("CLOUDINARY_URL");
            Account account = new Account (cloudinaryCloudName, cloudinaryApiKey, cloudinaryApiSecret);
            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
            string fileName = doctorDto.File.FileName;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, doctorDto.File.OpenReadStream()),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true,
                Folder="Medical System"
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            doctorDto.Image = uploadResult.SecureUrl.ToString();
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
