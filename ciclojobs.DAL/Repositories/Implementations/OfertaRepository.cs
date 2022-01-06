using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class OfertaRepository : IOfertasRepository
    {
        public ciclojobsContext _context;
        public OfertaRepository(ciclojobsContext context)
        {
            this._context = context;

        }
        public bool actualizarOfertas(Ofertas ofertas)
        {
            eliminarOfertas(ofertas.id);
            _context.Ofertas.Add(ofertas);
            _context.SaveChanges();
            return true;
        }

        public bool crearOfertas(Ofertas ofertas)
        {
            Console.WriteLine(ofertas);
            var u = _context.Ofertas.Add(ofertas);
            _context.SaveChanges();
            return true;
        }

        public bool eliminarOfertas(int id)
        {
            _context.Ofertas.Remove(obtenerOfertas(id));
            _context.SaveChanges();
            return true;
        }

        public bool existOfertas(Ofertas ofertas)
        {
            return _context.Ofertas.Any(u => u.nombre == ofertas.nombre && u.idempresas == ofertas.idempresas);
        }

        public Ofertas obtenerOfertas(int id)
        {
            return _context.Ofertas
                .Include(o => o.ciclo)
                .Include(o => o.empresas)
                .Include(o => o.empresas.provincias)
                .Include(o => o.ciclo)
                .ThenInclude(o => o.TipoCiclo)
                .Include(o => o.ciclo)
                .ThenInclude(o => o.familia)
                .FirstOrDefault(u => u.id == id);
        }

        public List<Ofertas> ObtenerOfertasCiclos(int id)
        {
            var ciclo = _context.Ciclo.FirstOrDefault(u => u.id == id);
            return _context.Ofertas
                .Include(o => o.ciclo)
                .Include(o => o.empresas)
                .Include(o => o.empresas.provincias)
                .Include(o => o.ciclo)
                .ThenInclude(o => o.TipoCiclo)
                .Include(o => o.ciclo)
                .ThenInclude(o => o.familia)
                .Where(u=> u.ciclo.Contains(ciclo))
                .ToList();
        }

        public List<Ofertas> obtenerOfertasempresa(int idempresa)
        {
            return _context.Ofertas
                .Include(o => o.ciclo)
                .Include(o => o.empresas)
                .Include(o => o.empresas.provincias)
                .Include(o => o.ciclo)
                .ThenInclude(o => o.TipoCiclo)
                .Include(o => o.ciclo)
                .ThenInclude(o => o.familia)
                .Where(o=>o.idempresas== idempresa)
                .ToList()
                ;
        }

        public List<Ofertas> obtenerTodosOfertas()
        {
            return _context.Ofertas
                .Include(o=>o.ciclo)
                .Include(o=>o.empresas)
                .Include(o=>o.empresas.provincias)
                .Include(o => o.ciclo)
                .ThenInclude(o => o.TipoCiclo)
                .Include(o => o.ciclo)
                .ThenInclude(o=>o.familia)
                .ToList();
        }

    }
}
