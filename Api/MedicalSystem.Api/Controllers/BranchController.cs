using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
       
        private readonly IBranchManager branchManager;
        public BranchController(IBranchManager _branchManager)
        {
            branchManager = _branchManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadBranchDto>> getAll()
        {
            var branches = branchManager.GetAll().Result;
            return Ok(branches);
        }

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

        [HttpPost]
        public ActionResult addBranch(AddBranchDto branch)
        {
            int newId = branchManager.Add(branch);
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
    }


}

