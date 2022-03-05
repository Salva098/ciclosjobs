﻿using ciclojobs.BL.Contracts;
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
            if (ContractoBL.ExistContract(contratoDTO))
            {


            contratoDTO = ContractoBL.Stripe(contratoDTO);
            var options = new SessionCreateOptions
            {
               
                SuccessUrl = "http://51.254.98.153/",
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
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Webhook")]
        public async Task<IActionResult> Index()
        {
          string endpointSecret = "whsec_5pfSRogsJoLLjxUe96VZuRHGTqbqTZFT";

            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);
                stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

<<<<<<< HEAD
                Console.WriteLine("Tipo del evento "+stripeEvent.Type);
=======
>>>>>>> parent of 50d5313 (Update ContractController.cs)
                // Handle the event
                if (stripeEvent.Type == Events.CustomerSubscriptionCreated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    ContractoBL.SubscriptionCreated(subscription);
                }
                else if (stripeEvent.Type == Events.InvoicePaid)
                {
                    var invoice = stripeEvent.Data.Object as Invoice;
                    ContractoBL.PagoSuccess(invoice);
                }
                //Esto no
                else if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    ContractoBL.PosiblePagoCancelacion(paymentIntent);
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok("Hola aniadido "+ stripeEvent.Type);
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
