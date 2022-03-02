using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
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
        public IMapper mapper { get; set; }
        public IConfiguration Configuration { get; set; }
        public IContratoRepository ContratoRepository { get; set; }
        public IEmpresaRepository empresaRepository { get; set; }
        public ContractoBL(IConfiguration Configuration, IContratoRepository ContratoRepository, IEmpresaRepository empresaRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.Configuration = Configuration;
            this.ContratoRepository = ContratoRepository;
            this.empresaRepository = empresaRepository;
        }

        public void PagoSuccess(Invoice invoice)
        {

            //invoice.Lines.Data[0].Period.Start;
            //invoice.Lines.Data[0].Period.End;
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


            var contrato = new Contrato
            {
                FechaBaja = subscription.CurrentPeriodEnd,
                FehchaAlta = subscription.CurrentPeriodStart,
                StripeId = subscription.Id,
                EmpresaID = empresaRepository.ObtenerEmpresaStripeID(subscription.CustomerId).id,
                EstadoContrato = ContratoEstado.incomplete,
                

            };
            Console.WriteLine("contrato creado")
            ContratoRepository.CrearFactura(contrato);
        }

        public bool ExistContract(ContratoDTO contratoDTO)
        {
            return ContratoRepository.ExistContract(mapper.Map<ContratoDTO, Contrato>(contratoDTO));
        }
    }
}
