using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class InscripcionesRepository : IInscripcionesRepository
    {
        public ciclojobsContext _context { get; set; }
        public InscripcionesRepository(ciclojobsContext _context)
        {
            this._context = _context;
        }
        public int CrearInscripcion(Inscripciones inscripcion)
        {

            if (!_context.Inscripciones.Any(u => u.idAlumno==inscripcion.idAlumno&&u.OfertaId==inscripcion.OfertaId))
            {
                var u = _context.Inscripciones.Add(inscripcion);
            _context.SaveChanges();
                return u.Entity.Id;
            }
            else
            {
                return -1;
            }
        }

        public bool DeleteInscripciones(Inscripciones inscripciones)
        {
            if (_context.Inscripciones.Any(u => u.idAlumno == inscripciones.idAlumno && u.OfertaId == inscripciones.OfertaId))
            {
                _context.Inscripciones.Remove(inscripciones);
                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Inscripciones> GetAllInscripciones()
        {
            return _context.Inscripciones
                .Include(u => u.Alumno)
                .Include(u => u.Alumno.provincia)
                .Include(u => u.Alumno.ciclo)
                .Include(u => u.Alumno.ciclo.familia)
                .Include(u => u.Alumno.ciclo.TipoCiclo)
                .Include(u => u.Oferta)
                .Include(u => u.Oferta.empresas)
                .Include(u => u.Oferta.empresas.provincias)
                .Include(u => u.Oferta.ciclo)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.familia)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.TipoCiclo)
                .ToList();
        }

        public Inscripciones GetInscripciones(int id)
        {
            return _context.Inscripciones
                .Include(u => u.Alumno)
                .Include(u => u.Alumno.provincia)
                .Include(u => u.Alumno.ciclo)
                .Include(u => u.Alumno.ciclo.familia)
                .Include(u => u.Alumno.ciclo.TipoCiclo)
                .Include(u => u.Oferta)
                .Include(u => u.Oferta.empresas)
                .Include(u => u.Oferta.empresas.provincias)
                .Include(u => u.Oferta.ciclo)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.familia)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.TipoCiclo)
                .FirstOrDefault(u => u.Id == id);
        }

        public List<Inscripciones> GetInscripcionesFamilia(int idfamilias)
        {
            var ciclos = _context.Ciclo
                .Where(u => u.idfamiliaprofe == idfamilias).Distinct().Select(u=>u.id).ToList();
            var ofertas = _context.Ofertas.Where(u => u.ciclo.Where(c=> ciclos.Contains(c.id)).Any()).ToList();
            return _context.Inscripciones
                .Include(u => u.Alumno)
                .Include(u => u.Alumno.provincia)
                .Include(u => u.Alumno.ciclo)
                .Include(u => u.Alumno.ciclo.familia)
                .Include(u => u.Alumno.ciclo.TipoCiclo)
                .Include(u => u.Oferta)
                .Include(u => u.Oferta.empresas)
                .Include(u => u.Oferta.empresas.provincias)
                .Include(u => u.Oferta.ciclo)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.familia)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.TipoCiclo)
                .Where(u => ofertas.Contains(u.Oferta)).ToList();
        }

        public bool UpdateInscripciones(Inscripciones inscripciones)
        {
            if (_context.Inscripciones.Any(u => u.idAlumno == inscripciones.idAlumno && u.OfertaId == inscripciones.OfertaId))
            {
                _context.Inscripciones.Update(inscripciones);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Inscripciones> GetInscripcionesTipo(int idtipo)
        {

            var ciclos = _context.Ciclo
            .Where(u => u.idtipo == idtipo).FirstOrDefault();
            var ofertas = _context.Ofertas
                .Where(u => u.ciclo.Contains(ciclos)).FirstOrDefault();
            return _context.Inscripciones
                .Include(u => u.Alumno)
                .Include(u => u.Alumno.provincia)
                .Include(u => u.Alumno.ciclo)
                .Include(u => u.Alumno.ciclo.familia)
                .Include(u => u.Alumno.ciclo.TipoCiclo)
                .Include(u => u.Oferta)
                .Include(u => u.Oferta.empresas)
                .Include(u => u.Oferta.empresas.provincias)
                .Include(u => u.Oferta.ciclo)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.familia)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.TipoCiclo)
                .Where(u => u.Oferta == ofertas).ToList();

        }

        public List<Inscripciones> GetInscripcionesfamiliaTipo(int familia, int idtipo)
        {
            var ciclos = _context.Ciclo
            .Where(u => u.idtipo == idtipo && u.idfamiliaprofe==familia).FirstOrDefault();
            var ofertas = _context.Ofertas
                .Where(u => u.ciclo.Contains(ciclos)).FirstOrDefault();
            return _context.Inscripciones
                .Include(u => u.Alumno)
                .Include(u => u.Alumno.provincia)
                .Include(u => u.Alumno.ciclo)
                .Include(u => u.Alumno.ciclo.familia)
                .Include(u => u.Alumno.ciclo.TipoCiclo)
                .Include(u => u.Oferta)
                .Include(u => u.Oferta.empresas)
                .Include(u => u.Oferta.empresas.provincias)
                .Include(u => u.Oferta.ciclo)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u=> u.familia)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.TipoCiclo)


                .Where(u => u.Oferta == ofertas).ToList();
        }

        public List<Inscripciones> GetInscripcionesCiclo(int idCiclo)
        {
            var ciclos = _context.Ciclo
               .Where(u => u.id==idCiclo).FirstOrDefault();
            var ofertas = _context.Ofertas
                .Where(u => u.ciclo.Contains(ciclos)).FirstOrDefault();
            return _context.Inscripciones
                .Include(u => u.Alumno)
                .Include(u => u.Alumno.provincia)
                .Include(u => u.Alumno.ciclo)
                .Include(u => u.Alumno.ciclo.familia)
                .Include(u => u.Alumno.ciclo.TipoCiclo)
                .Include(u => u.Oferta)
                .Include(u => u.Oferta.empresas)
                .Include(u => u.Oferta.empresas.provincias)
                .Include(u => u.Oferta.ciclo)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.familia)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.TipoCiclo)
                .Where(u => u.Oferta == ofertas).ToList();
        }

        public List<Inscripciones> GetInscripcionesEmpresa(int Empresa)
        {
            var ofertas = _context.Ofertas
                .Where(u => u.empresas.id == Empresa).ToList();
            return _context.Inscripciones
                .Include(u => u.Alumno)
                .Include(u => u.Alumno.provincia)
                .Include(u => u.Alumno.ciclo)
                .Include(u => u.Alumno.ciclo.familia)
                .Include(u => u.Alumno.ciclo.TipoCiclo)
                .Include(u => u.Oferta)
                .Include(u => u.Oferta.empresas)
                .Include(u => u.Oferta.empresas.provincias)
                .Include(u => u.Oferta.ciclo)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.familia)
                .Include(u => u.Oferta.ciclo)
                .ThenInclude(u => u.TipoCiclo)
                .Where(u => ofertas.Contains(u.Oferta)).ToList();
        }
    }
}
