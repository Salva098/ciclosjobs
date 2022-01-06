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

        public List<Ciclo> GetCicloTipoFamilia(int idtipo, int idfamilia)
        {
            return _context.Ciclo
                .Include(c => c.familia)
                .Include(c => c.TipoCiclo)
                .Where(u => u.idtipo == idtipo && u.idfamiliaprofe == idfamilia)
                .ToList();
        }

        public Ciclo ObtenerCiclo(int id)
        {
            return _context.Ciclo
                
                .Include(c => c.familia)
                .Include(c => c.TipoCiclo)
                .FirstOrDefault(c => c.id == id);
        }

        public List<Ciclo> ObtenerCiclosBuscados(int familia, int tipoCiclo)
        {
            return _context.Ciclo
                .Include(c => c.familia)
                .Include(c => c.TipoCiclo)
                .Where(u => u.idfamiliaprofe == familia && u.idtipo == tipoCiclo)
                .ToList();
        }

        public List<Ciclo> ObtenerTodoCiclos()
        {
            return _context.Ciclo
                .Include(c => c.familia)
                .Include(c => c.TipoCiclo)
                .ToList();
        }
    }
}
