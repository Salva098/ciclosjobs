using System;
using System.Collections.Generic;
using System.Text;

namespace ciclosjobs.Core.DTO.InscripcionesDTO
{
    public class InscripcionesDTO
    {
        public int Id { get; set; }

        public int idAlumno { get; set; }
        public AlumnoDTO Alumno { get; set; }

        public int OfertaId { get; set; }
        public OfertaDTO Oferta { get; set; }

        public DateTime FechaInscripcion { get; set; }
        public String EstadoInscripción { get; set; }
    }
}
