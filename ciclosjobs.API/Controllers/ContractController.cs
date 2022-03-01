using ciclojobs.BL.Contracts;
using ciclosjobs.Core.DTO.ContractoDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ciclosjobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        public IContractoBL ContractoBL { get; set; }
        public IConfiguration Configuration { get; set; }
        public ContractController(IContractoBL ContractoBL, IConfiguration Configuration)
        {
            this.ContractoBL = ContractoBL;
            this.Configuration = Configuration;
        }



        [HttpPost]
        [AllowAnonymous]
        public ActionResult<string> CrearPago(ContratoDTO contratoDTO)
        {
            contratoDTO = ContractoBL.Stripe(contratoDTO);
            var options = new SessionCreateOptions
            {
                SuccessUrl = "https://dashboard.stripe.com/test/webhooks/we_1KYTBOHssVim9VHFvIXZteFM",
                CancelUrl = "http://51.254.98.153/",
                PaymentMethodTypes = new List<string>
                  {
                    "card",
                  },
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>
                  {
                    new SessionLineItemOptions
                    {
                      Price = "price_1KWQ4SHssVim9VHFxcHhqUeS", //Tu priceID
                      // For metered billing, do not pass quantity
                      Quantity = 1,
                    },
                  },
                Customer = contratoDTO.Empresa.StripeID
                
            };

    

            var service = new SessionService();
            var session = service.Create(options);
            return Ok(session.Url);
        }


            const string endpointSecret = "whsec_5pfSRogsJoLLjxUe96VZuRHGTqbqTZFT";
        [HttpPost]
        [AllowAnonymous]
        [Route("Webhook")]
        public async Task<IActionResult> Index()
        {

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                // Handle the event
                if (stripeEvent.Type == Events.CustomerSubscriptionCreated)
                {
                }
                else if (stripeEvent.Type == Events.InvoicePaid)
                {
                }
                else if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
