using ciclojobs.DAL.Entities;
using ciclosjobs.Core.DTO.CiclosDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO
{
    public class OfertaDTORegistro
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double remuneracion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public String Horario { get; set; }
        public int idempresas { get; set; }

        public ICollection<CicloDTORegister> ciclo { get; set; }
    }
}
