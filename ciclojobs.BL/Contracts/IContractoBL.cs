using ciclosjobs.Core.DTO.ContractoDTO;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IContractoBL
    {
        ContratoDTO Stripe(ContratoDTO contratoDTO);
        void PagoSuccess(Invoice invoice);
        void SubscriptionCreated(Subscription subscription);
        void PosiblePagoCancelacion(PaymentIntent paymentIntent);
        bool ExistContract(ContratoDTO contratoDTO);
    }
}
