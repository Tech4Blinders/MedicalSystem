using MedicalSystem.BusinessLayer.Managers.Branches;
using MedicalSystem.CoreLayer.Dtos.BranchDtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers.Branch
{
    public class BranchController : Controller
    {
        private readonly IBranchManager branchManager;
        public BranchController(IBranchManager _branchManager)
        {
            branchManager = _branchManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadBranchDto>> getAll()
        {
            var branches = branchManager.GetAll();
            return Ok(branches);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadBranchDto> getById(int id)
        {
            var branch = branchManager.GetById(id);
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

