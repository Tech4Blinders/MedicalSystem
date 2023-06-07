
using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchAddressController : Controller
    {
        
        private readonly IBranchAddManager branchAddManager;
        public BranchAddressController(IBranchAddManager _branchAddManager)
        {
            branchAddManager = _branchAddManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadBranchAddressDto>> getAll()
        {
            var branchAddresses = branchAddManager.GetAll().Result;
            return Ok(branchAddresses);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ReadBranchAddressDto> getById(int id)
        {
            var branchAdd = branchAddManager.GetById(id).Result;
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
