using ciclojobs.DAL.Entities;
using ciclojobs.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ciclojobs.DAL.Repositories.Implementations
{
    public class FamiliaProfeRepository:IFamiliaProfeRepository
    {
              public ciclojobsContext _context;
        public FamiliaProfeRepository(ciclojobsContext context)
        {
            this._context = context;
        }

        public List<FamiliaProfe> getAllFamiliaProfe()
        {
            return _context.FamiliaProfe.ToList();
        }

        public List<FamiliaProfe> getFamiliaProfe(int tipoCiclo)
        {
            var ciclos = _context.Ciclo.Where(u => u.idtipo == tipoCiclo).Select(x => x.idfamiliaprofe).ToList();
            return _context.FamiliaProfe.Where(u=> ciclos.Contains(u.idprofe)).ToList() ;
        }
    }
}
