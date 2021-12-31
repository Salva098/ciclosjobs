using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface ITipoCicloRepository
    {
        public List<TipoCiclo> getAllTiposCiclos();
    }
}
