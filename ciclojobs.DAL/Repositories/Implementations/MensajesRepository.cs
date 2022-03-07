using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class MensajesRepository : IMensajesRepository
    {
        public ciclojobsContext _context { get; set; }
   
        public MensajesRepository()
        {
            this._context = _context;
        }
        public void CrearMensaje(Mensaje mensaje)
        {
            _context.Mensajes.Add(mensaje);
            _context.SaveChanges();
        }

        public List<Mensaje> NoLeidosAlumno(int idalumno)
        {
            return _context.Mensajes
                .Include(u=>u.Empresa)
                .Include(u=>u.Alumno)
                .Where(u => u.alumnoid == idalumno && !u.leido)
                .ToList();
        }

        public bool ExisteMensaje(int idalumno, int idmensaje)
        {
            return _context.Mensajes.Any(u => u.alumnoid == idalumno && u.id == idmensaje&&!u.leido);
        }

        public void LeerMensaje(Mensaje mensaje)
        {
            _context.Mensajes.Update(mensaje);
            _context.SaveChanges();
        }

        public Mensaje getMensaje(int idalumno, int idmensaje)
        {
            return _context.Mensajes
                .Include(u => u.Empresa)
                .Include(u => u.Alumno)
                .Where(u => u.alumnoid == idalumno&&u.id==idmensaje && !u.leido)
                .AsNoTracking()
                .First();
        }
    }
}
