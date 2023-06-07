using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;


namespace MedicalSystem.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchDoctorController : ControllerBase
    {
        private readonly IBranchDoctorManager _branchDoctorManager;

        public BranchDoctorController(IBranchDoctorManager branchDoctorManager)
        {
            _branchDoctorManager = branchDoctorManager;
        }

        [HttpGet]
        public ActionResult<List<BranchDoctorReadDto>> GetAll()
        {
            var branchdoctors = _branchDoctorManager.GetAll();
            if (branchdoctors.Count == 0)
            {
                return NoContent();
            }
            return Ok(branchdoctors);
        }

        [HttpGet("{id}")]
        public ActionResult<BranchDoctorReadDto> Get(int id)
        {
            var branchdoctor = _branchDoctorManager.GetById(id);
            if (branchdoctor == null)
            {
                return NotFound();
            }
            return Ok(branchdoctor);
        }

        [HttpPost]
        public ActionResult Add(BranchDoctorAddDto branchDoctorAddDto)
        {
            var newId = _branchDoctorManager.Add(branchDoctorAddDto);
            return CreatedAtAction("GetById", new { id = newId }, new { m = "branchdoctor has been added successfully" });

        }

        // PUT api/<BranchDoctorController>/5
        [HttpPut]
        public ActionResult Update(BranchDoctorUpdateDto branchDoctorDto)
        {
            var isFound = _branchDoctorManager.Update(branchDoctorDto);
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
            _branchDoctorManager.Delete(id);
            return NoContent();
        }
    }
}
