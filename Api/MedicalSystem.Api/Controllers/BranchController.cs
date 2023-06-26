using MedicalSystem.Api.Services.UploadImage;
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Authorization;
using MedicalSystem.CoreLayer.Dtos.BranchDtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BranchController : Controller
    {
       
        private readonly IBranchManager branchManager;
        private readonly IUploadImg uploadImg;
        public BranchController(IBranchManager _branchManager, IUploadImg _uploadImg)
        {
            branchManager = _branchManager;
            uploadImg = _uploadImg;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<ReadBranchDto>> getAll()
        //{
        //    var branches = branchManager.GetAll().Result;
        //    return Ok(branches);
        //}

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadBranchDto> getById(int id)
        {
            var branch = branchManager.GetById(id).Result;
            if (branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }
        [HttpGet]
        [Route("branches/{id}")]
        public ActionResult<HospitalWithBranches> getAllBranches(int id)
        {
            var branches = branchManager.GetAllBranches(id);
            if (branches == null)
            {
                return NotFound();
            }
            return Ok(branches);
        }

        [HttpPost]
        public ActionResult addBranch([FromForm] AddBranchDto branch)
        {
            if (branch.File == null || branch.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            branch.Image = uploadImg.uploadImg(branch.File.FileName, branch.File.OpenReadStream());
            int newId = branchManager.Add(branch);
            return CreatedAtAction("getById", new { id = newId }, new { m = "branch added successfully" });
        }

        [HttpPost("branchesWithAdd")]
        public ActionResult addBranchWithAddress([FromForm] AddBranchWithAddressDto branch)
        {
            if (branch.File == null || branch.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            branch.Image = uploadImg.uploadImg(branch.File.FileName, branch.File.OpenReadStream());
            int newId = branchManager.AddBranchWithAddres(branch);
            return CreatedAtAction("getById", new { id = newId }, new { m = "branch added successfully" });
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult delete(int id)
        {
            branchManager.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult update(UpdateBranchDto newBranch)
        {
            var response = branchManager.Update(newBranch);
            if (!response)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("Address")]
        public ActionResult GetAllWithAddress()
        {
            var branches = branchManager.GetByIdWithAddress().Result;
            return Ok(branches);
        }
    }


}

