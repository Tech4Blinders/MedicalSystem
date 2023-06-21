using MedicalSystem.CoreLayer;
using Stripe;

namespace MedicalSystem.Api
{
    public class StripeAppService : IStripeAppService
    {
        private readonly ChargeService _chargeService;
        private readonly TokenService _tokenService;
        public CustomerService _customerService;

        public StripeAppService(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
        }



        public async Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct)
        {
            TokenCreateOptions tokenOptions = new TokenCreateOptions
            {
                Card = new TokenCardOptions
                {
                    Name = customer.Name,
                    Number = customer.CreditCard.CardNumber,
                    ExpYear = customer.CreditCard.ExpirationYear,
                    ExpMonth = customer.CreditCard.ExpirationMonth,
                    Cvc = customer.CreditCard.Cvc
                }
            };

            // Create new Stripe Token
            //Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            // Set Customer options using
            CustomerCreateOptions customerOptions = new CustomerCreateOptions
            {
                Name = customer.Name,
                Email = customer.Email,
                Source = "tok_visa"
            };

            // Create customer at Stripe
            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

            // Return the created customer at stripe
            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }

        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            {
                // Set the options for the payment we would like to create at Stripe
                ChargeCreateOptions paymentOptions = new ChargeCreateOptions
                {
                    Customer = payment.CustomerId,
                    ReceiptEmail = payment.ReceiptEmail,
                    Description = payment.Description,
                    Currency = payment.Currency,
                    Amount = payment.Amount
                };

                // Create the payment
                var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

                // Return the payment to requesting method
                return new StripePayment(
                  createdPayment.CustomerId,
                  createdPayment.ReceiptEmail,
                  createdPayment.Description,
                  createdPayment.Currency,
                  createdPayment.Amount,
                  createdPayment.Id);
            }
        }
    }
}
