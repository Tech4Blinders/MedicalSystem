using MedicalSystem.BusinessLayer.Managers.BranchAddresses;
using MedicalSystem.BusinessLayer.Managers.Branches;
using MedicalSystem.CoreLayer.Dtos.BranchAddressDtos;
using MedicalSystem.CoreLayer.Dtos.BranchDtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    public class BranchAddressController : Controller
    {
        private readonly IBranchAddManager branchAddManager;
        public BranchAddressController(IBranchAddManager _branchAddManager)
        {
            branchAddManager = _branchAddManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadBranchAddressDto>> getAll()
        {
            var branchAddresses = branchAddManager.GetAll();
            return Ok(branchAddresses);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadBranchAddressDto> getById(int id)
        {
            var branchAdd = branchAddManager.GetById(id);
            if (branchAdd == null)
            {
                return NotFound();
            }
            return Ok(branchAdd);
        }

        [HttpPost]
        public ActionResult addBranchAdd(AddBranchAddressDto branchAdd)
        {
            int newId = branchAddManager.Add(branchAdd);
            return CreatedAtAction("getById", new { id = newId }, new { m = "branchAdd has been added successfully" });
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult delete(int id)
        {
            branchAddManager.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public ActionResult update(UpdateBranchAddressDto newBranchAdd)
        {
            var response = branchAddManager.Update(newBranchAdd);
            if (!response)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
