
using MedicalSystem.CoreLayer;
using Microsoft.AspNetCore.Mvc;

namespace MedicalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddStripeController : ControllerBase
    {
        private readonly IStripeAppService _stripeService;

        public AddStripeController(IStripeAppService stripeService)
        {
            _stripeService = stripeService;
        }
        [HttpPost("customer/add")]
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer(
            [FromBody] AddStripeCustomer customer,
            CancellationToken ct)
        {
            StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(
                customer,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }
        [HttpPost("payment/add")]
        public async Task<ActionResult<StripePayment>> AddStripePayment(
           [FromBody] AddStripePayment payment,
           CancellationToken ct)
        {
            StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(
                payment,
                ct);

            return StatusCode(StatusCodes.Status200OK, createdPayment);
        }
    }
}
