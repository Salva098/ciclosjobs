using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public ciclojobsContext _context;
        public UsuarioRepository(ciclojobsContext context)
        {
            this._context = context;

        }

        public Usuario Create(Usuario user)
        {
            var u = _context.Usuarios.Add(user);
            _context.SaveChanges();
            return u.Entity;
        }

        public bool Exists(Usuario user)
        {
            return _context.Usuarios.Any(u => u.Email == user.Email || u.username == user.username);
        }

        public bool Login(Usuario user)
        {
            return _context.Usuarios.Any(u => u.Email == user.Email && u.Password == user.Password);
        }
    }
}
