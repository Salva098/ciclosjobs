using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IStripeRepository
    {
        bool ExistFactruasEmpresa(int empresaid);
        void CrearContrato(Contrato contrato);
        Contrato ObtenerContratStripeID(string customerId);
        void CrearFactura(Facturas factura);
    }
}
