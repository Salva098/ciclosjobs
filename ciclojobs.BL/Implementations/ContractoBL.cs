using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO.ContractoDTO;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class ContractoBL : IContractoBL
    {
        public IConfiguration Configuration { get; set; }
        public IEmpresaRepository empresaRepository { get; set; }
        public ContractoBL(IConfiguration Configuration, IEmpresaRepository empresaRepository)
        {
            this.Configuration = Configuration;
            this.empresaRepository = empresaRepository;
        }

        public void PagoSuccess(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void PosiblePagoCancelacion(PaymentIntent paymentIntent)
        {
            throw new NotImplementedException();
        }

        public ContratoDTO Stripe(ContratoDTO contratoDTO)
        {
            StripeConfiguration.ApiKey = Configuration["Stripe:SecretKey"];

            #region Crear customer si no existe
            var empresa = empresaRepository.ObtenerEmpresa(contratoDTO.EmpresaID);
            if (empresa.StripeID == null)
            {
                var optionsCustomer = new CustomerCreateOptions
                {
                    Email = empresa.email
                };

                var serviceCustomer = new CustomerService();
                var customer = serviceCustomer.Create(optionsCustomer);
                empresa.StripeID = customer.Id;
                empresaRepository.ActualizarEmpresa(empresa);
            }
            contratoDTO.Empresa = empresa;
            #endregion
            return contratoDTO;
        }

        public void SubscriptionCreated(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
