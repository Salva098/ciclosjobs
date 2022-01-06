using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface ICicloRepository
    {
        public Ciclo ObtenerCiclo(int id);
        public List<Ciclo> ObtenerTodoCiclos();

        public List<Ciclo> ObtenerCiclosBuscados(int familia, int tipoCiclo);
        public List<Ciclo> GetCicloTipoFamilia(int idtipo, int idfamilia);
    }
}
