using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class CicloRepository : ICicloRepository
    {
        public ciclojobsContext _context;
        public CicloRepository(ciclojobsContext context)
        {
            this._context = context;

        }
        public Ciclo ObtenerCiclo(int id)
        {
            return _context.Ciclo
                
                .Include(c => c.familia)
                .Include(c => c.TipoCiclo)
                .FirstOrDefault(c => c.id == id);
        }
    }
}
