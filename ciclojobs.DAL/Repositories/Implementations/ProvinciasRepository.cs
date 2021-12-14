using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class ProvinciasRepository : IProvinciasRepository
    {
             public ciclojobsContext _context;
        public ProvinciasRepository(ciclojobsContext context)
        {
            this._context = context;

        }
    
        public Provincias ObtenerProvincia(int id)
        {
            return _context.Provincias.FirstOrDefault(p => p.id == id);
        }

        public List<Provincias> ObtenerTodoProvincia()
        {
            return _context.Provincias.ToList();
        }
    }
}
