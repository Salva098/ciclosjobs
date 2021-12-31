using ciclosjobs.Core.DTO.FamiliaProfeDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.BL.Contracts
{
    public interface IFamiliaProfeBL
    {
        public List<FamiliaProfeDTO> getAllFamiliaProfe();
        public List<FamiliaProfeDTO> getFamiliaProfe(int tipoCiclo);

    }
}
