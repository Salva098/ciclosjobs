using AutoMapper;
using ciclojobs.BL.Contracts;
using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using ciclosjobs.Core.DTO;
using ciclosjobs.Core.DTO.ContractoDTO;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Implementations
{
    public class StripeBL : IContractoBL
    {
        public IMapper mapper { get; set; }
        public IConfiguration Configuration { get; set; }
        public IStripeRepository ContratoRepository { get; set; }
        public IEmpresaRepository empresaRepository { get; set; }
        public StripeBL(IConfiguration Configuration, IStripeRepository ContratoRepository, IEmpresaRepository empresaRepository, IMapper mapper)
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
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);



            Facturas factura = new Facturas
            {
                EmpresaID = empresa.id,
                ContratoID = contrato.id,
                FechaCreacion = invoice.Created,
                FechaFin= dateTime.AddMilliseconds(invoice.Lines.Data[0].Period.End) ,
                FechaPago = (DateTime)invoice.StatusTransitions.PaidAt,
                StripePriceID = invoice.Lines.Data[0].Price.Id

            };
            ContratoRepository.CrearFactura(factura);
        }

        public ContratoDTO Stripe(ContratoDTO contratoDTO)
        {
            StripeConfiguration.ApiKey = Configuration["Stripe:SecretKey"];

            #region Crear customer si no existe
            var empresa = empresaRepository.ObtenerEmpresa(contratoDTO.Empresa.id);
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
            contratoDTO.Empresa = mapper.Map<Empresa, EmpresaDTO>(empresa);
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

        public bool ExistFactruasEmpresa(int empresaid)
        {
            return ContratoRepository.ExistFactruasEmpresa(empresaid);
        }
    }
}
