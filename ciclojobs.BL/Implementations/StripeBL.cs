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
    public class StripeBL : IStripeBL
    {
        public IMapper mapper { get; set; }
        public IConfiguration Configuration { get; set; }
        public IContratoRepository ContratoRepository { get; set; }
        public IEmpresaRepository empresaRepository { get; set; }
        public StripeBL(IConfiguration Configuration, IContratoRepository ContratoRepository, IEmpresaRepository empresaRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.Configuration = Configuration;
            this.ContratoRepository = ContratoRepository;
            this.empresaRepository = empresaRepository;
        }

        public void PagoSuccess(Invoice invoice)
        {
            var empresa = empresaRepository.ObtenerEmpresaStripeID(invoice.CustomerId);

            var contrato = ContratoRepository.ObtenerContratStripeID(invoice.SubscriptionId);
            Console.WriteLine("EmpresaID => " + empresa.id);
            Console.WriteLine("stripeID => " + empresa.StripeID);
            Console.WriteLine("ContratoID => " + contrato);
            Console.WriteLine("FechaCreacion => " + invoice.Created);
            Console.WriteLine("FechaPago => " + (DateTime)invoice.StatusTransitions.PaidAt);
            Console.WriteLine("StripePriceID => " + invoice.Lines.Data[0].Price.Id);

            
            
            Facturas factura = new Facturas
            {
                EmpresaID = empresa.id,
                ContratoID = contrato.id,
                FechaCreacion = invoice.Created,
                FechaPago = (DateTime)invoice.StatusTransitions.PaidAt,
                StripePriceID = invoice.Lines.Data[0].Price.Id

            };
            ContratoRepository.CrearFactura(factura);
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

            var idempresa = empresaRepository.ObtenerEmpresaStripeID(subscription.CustomerId).id;
            var contrato = new Contrato
            {
                
                FechaBaja = subscription.CurrentPeriodEnd,
                FehchaAlta = subscription.CurrentPeriodStart,
                StripeId = subscription.Id,
                EmpresaID = idempresa,
                EstadoContrato = ContratoEstado.incomplete,
                

            };
            Console.WriteLine("contrato creado");
            ContratoRepository.CrearContrato(contrato);
        }

        public bool ExistContractEmpresa(int empresaid)
        {
            return ContratoRepository.ExistContractEmpresa(empresaid);
        }
    }
}
