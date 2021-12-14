using ciclojobs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO
{
    public class CicloDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idfamiliaprofe { get; set; }
        public FamiliaProfe familia { get; set; }
        public int idtipo { get; set; }
        public TipoCiclo TipoCiclo { get; set; }

    }
}
