using MedicalSystem.BusinessLayer;
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IReviewManager _ReviewManager;

		public ReviewController(IReviewManager ReviewManager)
		{
			_ReviewManager = ReviewManager;
		}

		[HttpGet]
		public ActionResult<List<ReviewWithIdDto>> GetAll()
		{
			var Reviews = _ReviewManager.GetAll();
			if (Reviews.Count == 0)
			{
				return NoContent();
			}
			return Ok(Reviews);
		}

		// GET api/<ReviewController>/5
		[HttpGet("{id}")]
		public ActionResult<IEnumerable<ReviewWithIdDto>> Get(int id)
		{
			var Review = _ReviewManager.GetById(id);
			if (Review == null)
			{
				return NotFound();
			}
			return Ok(Review);
		}

		[HttpPost]
		public ActionResult<int> Add(ReviewAddDto Review)
		{
			var newId = _ReviewManager.Add(Review);
			return newId;
			//return CreatedAtAction("GetById", new { id = newId }, new { m = "Review has been added successfully" });

		}

		// PUT api/<ReviewController>/5
		[HttpPut]
		public ActionResult Update(ReviewUpdateDto Review)
		{
			var isFound = _ReviewManager.Update(Review);
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
			_ReviewManager.Delete(id);
			return NoContent();
		}
	}
}
