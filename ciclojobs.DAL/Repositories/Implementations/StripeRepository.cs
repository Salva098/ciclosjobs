using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class StripeRepository : IStripeRepository
    {
        public ciclojobsContext _context;
        public StripeRepository(ciclojobsContext _context)
        {
            this._context = _context;
        }

        public void CrearContrato(Contrato contrato)
        {
            _context.Contrato.Add(contrato);
            Console.WriteLine("aniadido en la base de datos");
            _context.SaveChanges();
        }

        public void CrearFactura(Facturas factura)
        {
            _context.Facturas.Add(factura);
            Console.WriteLine("aniadido en la base de datos");
            _context.SaveChanges();
        }

        public bool ExistFactruasEmpresa(int empresaid)
        {
           return  _context.Facturas.Any(u => u.EmpresaID == empresaid && u.FechaFin >DateTime.Now);
        }

        public Contrato ObtenerContratStripeID(string customerId)
        {
            return _context.Contrato.Where(u => u.StripeId== customerId).First();
        }
    }
}
