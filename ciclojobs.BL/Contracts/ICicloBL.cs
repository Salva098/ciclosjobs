using ciclosjobs.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface ICicloBL
    {
        public CicloDTO ObtenerCiclo(int id);
        public List<CicloDTO> ObtenerTodoCiclo();

    }
}
