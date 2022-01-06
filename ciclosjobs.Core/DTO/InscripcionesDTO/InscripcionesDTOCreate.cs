using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO.InscripcionesDTO
{
    public class InscripcionesDTOCreate
    {
      
        public int idAlumno { get; set; }


        public int OfertaId { get; set; }

        public DateTime FechaInscripcion { get; set; }
        public String EstadoInscripción { get; set; }
    }
}
