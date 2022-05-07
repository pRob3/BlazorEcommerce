using Stripe;
using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;
        private readonly IConfiguration _config;

        

        public PaymentService(ICartService cartService, IAuthService authService, IOrderService orderService, IConfiguration config)
        {
            //StripeConfiguration.ApiKey = _config["Swipe:ServiceApiKey"];
            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
            _config = config;
        }


        public async Task<Session> CreateCheckoutSession()
        {
            StripeConfiguration.ApiKey = _config["Swipe:ServiceApiKey"];

            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity = product.Quantity
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "SE" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7024/order-success",
                CancelUrl = "https://localhost:7024/cart"
            };



            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            StripeConfiguration.ApiKey = _config["Swipe:ServiceApiKey"];
            string secret = _config["Swipe:TestSecretKey"];

            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    request.Headers["Stripe-Signature"],
                    secret
                    );

                if(stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);

                    await _orderService.PlaceOrder(user.Id);
                }
            }
            catch (StripeException e)
            {

                return new ServiceResponse<bool> { Data = false, Success = false, Message = e.Message };
            }

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
