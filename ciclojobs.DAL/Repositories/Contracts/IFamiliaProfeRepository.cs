using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclojobs.DAL.Repositories.Contracts
{
    public interface IFamiliaProfeRepository
    {

        public List<FamiliaProfe> getAllFamiliaProfe();
        public List<FamiliaProfe> getFamiliaProfe(int tipoCiclo);
    }
}
