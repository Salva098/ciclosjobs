using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class TipoCicloRepository:ITipoCicloRepository
    {
        public ciclojobsContext _context;
        public TipoCicloRepository(ciclojobsContext context)
        {
            this._context = context;

        }

        public List<TipoCiclo> getAllTiposCiclos()
        {
            return _context.TipoCiclo.ToList();
        }
    }
}
