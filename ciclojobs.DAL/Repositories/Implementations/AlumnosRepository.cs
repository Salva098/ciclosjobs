using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class AlumnosRepository : IAlumnosRepository
    {
        public ciclojobsContext _context;
        public AlumnosRepository(ciclojobsContext context)
        {
            this._context = context;

        }
        public Alumno ActualizarAlumno(Alumno alumno)
        {
            
            var u = _context.Alumno.Update(alumno);
            
            _context.SaveChanges();
            return u.Entity;
        }

        public Alumno CrearAlumnos(Alumno alumno)
        {
            var u = _context.Alumno.Add (alumno);
            _context.SaveChanges();
            return u.Entity;
        }

        public bool EliminarAlumno(Alumno alumno)
        {
            _context.Alumno.Remove(alumno);
            _context.SaveChanges();
            return true;

        }

        public bool ExistAlumnos(Alumno alumno)
        {
            return _context.Alumno
                .Any(u => u.email== alumno.email);
        }

        public bool Login(Alumno alumno)
        {
            return _context.Alumno
                 .Any(u => u.email == alumno.email && u.contrasena ==alumno.contrasena);
        }

        public Alumno ObtenerAlumno(int id)
        {
            return _context.Alumno
                .Include(p => p.provincia)
                .Include(p => p.ciclo.familia)
                .Include(c => c.ciclo.TipoCiclo)
                .Include(c => c.ciclo)
                .FirstOrDefault(e => e.id == id);

        }

        public List<Alumno> ObtenerTodosAlumnos()
        {
            return _context.Alumno
                .Include(p => p.provincia)
                .Include(p => p.ciclo.familia)
                .Include(c => c.ciclo.TipoCiclo)
                .Include(c => c.ciclo)
                .ToList();
        }

        public Alumno BuscaPorEmail(Alumno Alumno)
        {

            return _context.Alumno.FirstOrDefault(a => a.email == Alumno.email);

        }

    }
}
