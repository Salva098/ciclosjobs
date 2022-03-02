using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public ciclojobsContext _context;
        public EmpresaRepository(ciclojobsContext context)
        {
            this._context = context;

        }
        public Empresa ActualizarEmpresa(Empresa empresa)
        {

            var u = _context.Empresa.Update(empresa);
            _context.SaveChanges();
            return u.Entity;


        }
        public Empresa ObtenerEmpresaStripeID(string StripeId)
        {

            if (_context.Empresa.Any(u => u.StripeID == StripeId))
            {
                return _context.Empresa.FirstOrDefault(u => u.StripeID == StripeId);

            }
            else
            {
                return null;
            }


        }

        public Empresa BuscaPorEmail(string email)
        {
            if (_context.Empresa.Any(u=>u.email==email))
            {
            return _context.Empresa.FirstOrDefault(u => u.email == email);

            }
            else
            {
                return null;
            }
        }

        public bool CheckAccount(string email)
        {
            return _context.Empresa.Where(u => u.email == email).Select(u => u.verificado).FirstOrDefault();
        }

        public bool CrearEmpresa(Empresa empresa)
        {
            var u = _context.Empresa.Add(empresa);
            _context.SaveChanges();
            return true;
        }

        public bool EliminarEmpresa(Empresa empresa)
        {
            _context.Empresa.Remove(empresa);
            _context.SaveChanges();
            return true;

        }
        public bool ExistEmpresa(Empresa empresa)
        {
            return _context.Empresa.Any(u => u.email == empresa.email);
        }

        public bool LoginEmpresa(Empresa empresa)
        {
            return _context.Empresa.Any(u => u.email == empresa.email && u.contrasena == empresa.contrasena);
            
        }


        public Empresa ObtenerEmpresa(int id)
        {
            return _context.Empresa
                .Include(e => e.provincias)
                .FirstOrDefault(e => e.id==id);
                
        }

        public Empresa ObtenerPorEmail(string Email)
        {
            return _context.Empresa
                .Include(e => e.provincias)
                .AsNoTracking()
                .FirstOrDefault(e => e.email == Email);
        }

        public List<Empresa> ObtenerTodosEmpresa()
        {
            return _context.Empresa
                .Include(e => e.provincias)
                .ToList();
        }

        public bool VerificarCode(string email, string code)
        {
            return _context.Empresa.Any(u => u.email == email && u.codeverify == code);
            
        }
    }
}
